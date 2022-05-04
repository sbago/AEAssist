using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AEAssist.AI;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot.Enums;
using ff14bot.Managers;

namespace AEAssist.Rotations.Core
{
    public class RotationManager
    {
        public static RotationManager Instance = new RotationManager();

        private ClassJobType _classJobType;

        public Dictionary<ClassJobType, IRotation> AllRotations = new Dictionary<ClassJobType, IRotation>();

        public DefaultRotation DefaultRotation = new DefaultRotation();

        public void Init()
        {
            AllRotations.Clear();
            var baseType = typeof(IRotation);
            foreach (var type in GetType().Assembly.GetTypes())
            {
                if (type.IsAbstract || type.IsInterface)
                    continue;
                if (!baseType.IsAssignableFrom(type))
                    continue;
                if (type == typeof(DefaultRotation))
                    continue;
                var attrs = type.GetCustomAttributes(typeof(RotationAttribute), false);
                if (attrs.Length == 0)
                {
                    LogHelper.Error($"Rotation class [{type}] need RotationAttribute");
                    continue;
                }

                var attr = attrs[0] as RotationAttribute;
                AllRotations[attr.ClassJobType] = Activator.CreateInstance(type) as IRotation;
                LogHelper.Debug("Load Rotation: " + attr.ClassJobType);
            }
        }

        public void CheckChangeJob()
        {
            if (_classJobType != ff14bot.Core.Me.CurrentJob)
            {
                _classJobType = ff14bot.Core.Me.CurrentJob;
                GetRotation().Init();
            }
        }

        private IRotation GetRotation()
        {
            if (AllRotations.TryGetValue(ff14bot.Core.Me.CurrentJob, out var job)) return job;

            return DefaultRotation;
        }

        public Task<bool> Rest()
        {
            return Task.FromResult(false);
        }

        public async Task<bool> PreCombatBuff()
        {
            await CountDownHandler.Instance.Update();
            if (CountDownHandler.Instance.Start)
                return false;
            if (ff14bot.Core.Me.InCombat) return false;
            AIRoot.Instance.Clear();

            if (ff14bot.Core.Me.HasTarget && ff14bot.Core.Me.CurrentTarget.CanAttack)
                return false;

            if (MovementManager.IsMoving)
                return false;
            return await GetRotation().PreCombatBuff();
        }

        public Task<bool> Pull()
        {
            return Task.FromResult(false);
        }

        public async Task<bool> Heal()
        {
            try
            {
                await CountDownHandler.Instance.Update();
                TargetMgr.Instance.Update();
                return await AIRoot.Instance.Update();
            }
            catch (Exception e)
            {
                LogHelper.Error(e.ToString());
            }

            return false;
        }

        public Task<bool> CombatBuff()
        {
            return Task.FromResult(false);
        }

        public Task<bool> Combat()
        {
            return Task.FromResult(false);
        }

        public Task<bool> PullBuff()
        {
            return Task.FromResult(false);
        }

        public SpellEntity GetBaseGCDSpell()
        {
            return GetRotation().GetBaseGCDSpell();
        }
    }
}