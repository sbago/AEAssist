using System.Threading.Tasks;
using ff14bot.Objects;

namespace AEAssist
{
    public class DefaultRotation : IRotation
    {
        public void Init()
        {
        }

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

        public SpellData GetBaseGCDSpell()
        {
            return null;
        }

        public void HandleInCountDown1500()
        {
        }
    }
}