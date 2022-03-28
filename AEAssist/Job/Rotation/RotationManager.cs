using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AEAssist.AI;
using ff14bot.Enums;

namespace AEAssist
{
    public class RotationManager
    {
        public static RotationManager Instance = new RotationManager();

        public DefaultRotation DefaultRotation = new DefaultRotation();

        public Dictionary<ClassJobType, IRotation> AllRotations = new Dictionary<ClassJobType, IRotation>();

        public void Init()
        {
            this.AllRotations.Clear();
            var baseType = typeof(IRotation);
            foreach (var type in this.GetType().Assembly.GetTypes())
            {
                if(type.IsAbstract || type.IsInterface)
                    continue;
                if(!baseType.IsAssignableFrom(type))
                    continue;
                if(type == typeof(DefaultRotation))
                    continue;
                var attrs = type.GetCustomAttributes(typeof(RotationAttribute), false);
                if (attrs.Length == 0)
                {
                    LogHelper.Error($"Rotation class [{type}] need RotationAttribute");
                    continue;
                }

                var attr = attrs[0] as RotationAttribute;
                this.AllRotations[attr.ClassJobType] = Activator.CreateInstance(type) as IRotation;
                LogHelper.Info("Load Rotation: " + attr.ClassJobType);
            }
            
            foreach (var v in AllRotations)
            {
                v.Value.Init();
            }
        }

        IRotation GetRotation()
        {
            if (AllRotations.TryGetValue(ff14bot.Core.Me.CurrentJob, out var job))
            {
                return job;
            }

            return DefaultRotation;
        }

        public Task<bool> Rest()
        {
            return GetRotation().Rest();
        }

        public Task<bool> PreCombatBuff()
        {
            return GetRotation().PreCombatBuff();
        }

        public Task<bool> Pull()
        {
            return GetRotation().Pull();
        }

        public Task<bool> Heal()
        {
            return GetRotation().Heal();
        }

        public Task<bool> CombatBuff()
        {
            return GetRotation().CombatBuff();
        }

        public Task<bool> Combat()
        {
            return GetRotation().Combat();
        }

        public Task<bool> PullBuff()
        {
            return GetRotation().PullBuff();
        }
    }
}