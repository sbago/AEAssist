using System.Threading.Tasks;
using AEAssist.AI;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Objects;

namespace AEAssist
{
    public class BardRotation : IRotation
    {

        private AIRoot AiRoot = new AIRoot();
        public Task<bool> Rest()
        {
            var needRest = Core.Me.CurrentHealthPercent < BardSettings.Instance.RestHealthPercent;
            return Task.FromResult(needRest);
        }

        // 战斗之前处理buff的?
        public async Task<bool> PreCombatBuff()
        {
            if (Core.Me.HasTarget && Core.Me.CurrentTarget.CanAttack)
                return false;

            if(Core.Me.ContainAura(AurasDefine.Peloton,1000))
                return false;

            return await SpellHelper.CastAbility(Spells.Peloton, Core.Me);
        }

        public Task<bool> Pull()
        {
            //LogHelper.Debug("Pull");
            return Combat();
        }

        public Task<bool> Heal()
        {
            return Task.FromResult(false);
        }

        public Task<bool> CombatBuff()
        {
            return Task.FromResult(false);
        }

        public Task<bool> Combat()
        {
            return AiRoot.Update();
        }

        public Task<bool> PullBuff()
        {
            LogHelper.Debug("PullBuff");
            return Task.FromResult(true);
        }
    }
}