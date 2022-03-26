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

        public Dictionary<ClassJobType, IRotation> AllRotations = new Dictionary<ClassJobType, IRotation>()
        {
            {ClassJobType.Bard,new BardRotation()}
        };

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