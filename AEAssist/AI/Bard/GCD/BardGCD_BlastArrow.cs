using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Objects;

namespace AEAssist.AI
{
    public class BardGCD_BlastArrow : IAIHandler
    {
        public int Check(SpellData lastSpell)
        {
            if (!DataBinding.Instance.UseApex)
                return -1;
            if (!Core.Me.HasAura(AurasDefine.BlastArrowReady))
                return -2;

            if (SpellsDefine.RagingStrikes.RecentlyUsed() || BardSpellHelper.HasBuffsCount() >= 1)
                return 1;
            

            var aura = Core.Me.GetAuraById(AurasDefine.BlastArrowReady);
            var buffTime = SpellsDefine.RagingStrikes.Cooldown.TotalMilliseconds;
            if (SpellsDefine.RagingStrikes.IsReady())
                buffTime = 0;

            if (DataBinding.Instance.EarlyDecisionMode)
                buffTime += SettingMgr.GetSetting<GeneralSettings>().ActionQueueMs;
            
            // Buff持续时间内需要补毒,那么立即打出去
            if (BardSpellHelper.IsTargetNeedIronJaws(Core.Me.CurrentTarget as Character, (int)aura.TimespanLeft.TotalMilliseconds))
                return 3;
            
            // 如果可以等到猛者,就等一下
            if (aura.TimespanLeft.TotalMilliseconds >= buffTime + ConstValue.AuraTick) return -4;

            return 0;
        }

        public async Task<SpellData> Run()
        {
            var spell = BardSpellHelper.GetBlastArrow();
            if (spell == null)
                return null;
            var ret = await SpellHelper.CastGCD(spell, Core.Me.CurrentTarget);
            if (ret)
                return spell;
            return null;
        }
    }
}