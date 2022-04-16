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
            return 0;
        }

        public async Task<SpellData> Run()
        {
            if (SpellsDefine.AutoCrossbow.IsUnlock() && TargetHelper.CheckNeedUseAOE(12, 12))
            {
                if (await SpellHelper.CastGCD(SpellsDefine.AutoCrossbow, Core.Me.CurrentTarget))
                {
                    return SpellsDefine.AutoCrossbow;
                }
            }
            
            if (await SpellHelper.CastGCD(SpellsDefine.HeatBlast, Core.Me.CurrentTarget))
            {
                AIRoot.GetBattleData<BattleData>().LimitAbility = true;
                
                return SpellsDefine.HeatBlast;
            }

            return null;
        }
    }
}