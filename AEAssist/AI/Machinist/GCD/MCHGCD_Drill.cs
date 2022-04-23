using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Objects;

namespace AEAssist.AI.MCH
{
    public class MCHGCD_Drill : IAIHandler
    {
        public int Check(SpellData lastSpell)
        {
            if (!SpellsDefine.Drill.IsReady())
                return -1;
            
            // 整备只有1层的时候,如果3秒内能冷却好,等一下
            if (!SpellsDefine.Reassemble.RecentlyUsed() && SpellsDefine.Reassemble.MaxCharges < 1.5f && SpellsDefine.Reassemble.Cooldown.TotalMilliseconds < 3000)
            {
                return -3;
            }
            
            return 0;
        }

        public async Task<SpellData> Run()
        {
            if (TargetHelper.CheckNeedUseAOE(Core.Me.CurrentTarget, 12, 12))
            {
                if (await SpellHelper.CastGCD(SpellsDefine.Bioblaster, Core.Me.CurrentTarget))
                {
                    return SpellsDefine.Bioblaster;
                }
            }

            if (await SpellHelper.CastGCD(SpellsDefine.Drill, Core.Me.CurrentTarget))
            {
                return SpellsDefine.Drill;
            }

            return null;
        }
    }
}