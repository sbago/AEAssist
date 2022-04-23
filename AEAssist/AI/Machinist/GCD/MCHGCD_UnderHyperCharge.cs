using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist.AI.MCH
{
    public class MCHGCD_UnderHyperCharge : IAIHandler
    {
        public int Check(SpellData lastSpell)
        {
            if (ActionResourceManager.Machinist.OverheatRemaining.TotalMilliseconds <= 0)
                return -1;
            
            if (AIRoot.GetBattleData<MCHBattleData>().HyperchargeGCDCount <= 0)
            {
                return -2;
            }

            return 0;
        }

        public async Task<SpellData> Run()
        {
            var spell = MCHSpellHelper.GetUnderHyperChargeGCD();
            if (await SpellHelper.CastGCD(spell, Core.Me.CurrentTarget))
            {
                AIRoot.GetBattleData<BattleData>().LimitAbility = true;
                AIRoot.GetBattleData<MCHBattleData>().HyperchargeGCDCount--;
                return spell;
            }
            return null;
        }
    }
}