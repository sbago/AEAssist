using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AEAssist.AI;
using ff14bot;
using ff14bot.Enums;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist
{
    public class RotationManager
    {
        public static RotationManager Instance = new RotationManager();

        public Dictionary<ClassJobType, IRotation> AllRotations = new Dictionary<ClassJobType, IRotation>();

        public DefaultRotation DefaultRotation = new DefaultRotation();

        private ClassJobType _classJobType;

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
                LogHelper.Info("Load Rotation: " + attr.ClassJobType);
            }
        }

        public void CheckChangeJob()
        {
            if (_classJobType != Core.Me.CurrentJob)
            {
                _classJobType = Core.Me.CurrentJob;
                GetRotation().Init();
            }
        }

        private IRotation GetRotation()
        {
            if (AllRotations.TryGetValue(Core.Me.CurrentJob, out var job)) return job;

            return DefaultRotation;
        }

        public Task<bool> Rest()
        {
            return Task.FromResult(false);
        }

        public Task<bool> PreCombatBuff()
        {
            return GetRotation().PreCombatBuff();
        }

        public Task<bool> Pull()
        {
            return Task.FromResult(false);
        }

        public async Task<bool> Heal()
        {
            await CountDownHandler.Instance.Update();
            TargetMgr.Instance.Update();
            return await AIRoot.Instance.Update();
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

        public SpellData GetBaseGCDSpell()
        {
            return GetRotation().GetBaseGCDSpell();
        }
    }
}