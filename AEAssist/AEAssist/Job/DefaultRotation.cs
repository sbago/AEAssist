using System.Threading.Tasks;

namespace AEAssist.Job
{
    public class DefaultRotation : IRotation
    {
        public Task<bool> Rest()
        {
            // LogHelper.Debug("Rest");
            return Task.FromResult(false);
        }

        public Task<bool> PreCombatBuff()
        {
            //   LogHelper.Debug("PreCombatBuff");
            return Task.FromResult(false);
        }

        public Task<bool> Pull()
        {
            //  LogHelper.Debug("Pull");
            return Task.FromResult(true);
        }

        public Task<bool> Heal()
        {
            //  LogHelper.Debug("Heal");
            return Task.FromResult(true);
        }

        public Task<bool> CombatBuff()
        {
            //   LogHelper.Debug("CombatBuff");
            return Task.FromResult(true);
        }

        public Task<bool> Combat()
        {
            //  LogHelper.Debug("Combat");
            return Task.FromResult(true);
        }

        public Task<bool> PullBuff()
        {
            // LogHelper.Debug("PullBuff");
            return Task.FromResult(true);
        }
    }
}