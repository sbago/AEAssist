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
        public int Check(SpellEntity lastSpell)
        {
            if (ActionResourceManager.Machinist.OverheatRemaining.TotalMilliseconds <= 0)
                return -1;
            
            if (AIRoot.GetBattleData<MCHBattleData>().HyperchargeGCDCount >= 5)
            {
                return -2;
            }

            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            var spell = MCHSpellHelper.GetUnderHyperChargeGCD();
            if (await spell.DoGCD())
            {
                return spell;
            }
            return null;
        }
    }
}