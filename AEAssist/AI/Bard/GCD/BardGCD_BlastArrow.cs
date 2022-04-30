using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Objects;

namespace AEAssist.AI
{
    public class BardGCD_BlastArrow : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            if (!DataBinding.Instance.UseApex)
                return -1;
            if (!Core.Me.HasAura(AurasDefine.BlastArrowReady))
                return -2;
            
            if (AIRoot.Instance.CloseBurst)
                return 1;
            var aura = Core.Me.GetAuraById(AurasDefine.BlastArrowReady);
            var tar = Core.Me.CurrentTarget as Character;
            
            // Buff持续时间内需要补毒,那么先等补毒
            if (BardSpellHelper.IsTargetNeedIronJaws(Core.Me.CurrentTarget as Character, (int)aura.TimespanLeft.TotalMilliseconds - 2500))
                return -3;

            if (aura.TimespanLeft.TotalMilliseconds <= 2500)
                return 3;

            if (SpellsDefine.RagingStrikes.RecentlyUsed() || BardSpellHelper.HasBuffsCount() >= 1)
                return 4;
            
            if (TargetHelper.CheckNeedUseAOE(25, 2, ConstValue.BardAOECount))
                return 5;
            
            
            var buffTime = SpellsDefine.RagingStrikes.GetSpellEntity().Cooldown.TotalMilliseconds;
            if (SpellsDefine.RagingStrikes.IsReady())
                buffTime = 0;

            if (DataBinding.Instance.EarlyDecisionMode)
                buffTime += SettingMgr.GetSetting<GeneralSettings>().ActionQueueMs;
            
            
            
            // 如果可以等到猛者,就等一下
            if (aura.TimespanLeft.TotalMilliseconds >= buffTime + ConstValue.AuraTick) return -4;

            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            var spell = BardSpellHelper.GetBlastArrow();
            if (spell == null)
                return null;
            var ret = await spell.DoGCD();
            if (ret)
                return spell;
            return null;
        }
    }
}