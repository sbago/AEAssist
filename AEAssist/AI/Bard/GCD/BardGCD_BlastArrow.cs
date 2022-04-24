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
            
            var tar = Core.Me.CurrentTarget as Character;
            var timeLeft = SettingMgr.GetSetting<BardSettings>().Dot_TimeLeft;
            if (BardSpellHelper.IsTargetNeedIronJaws(tar,timeLeft))
                return -3;

            if (SpellsDefine.RagingStrikes.RecentlyUsed() || BardSpellHelper.HasBuffsCount() >= 1)
                return 2;
            
            if (TargetHelper.CheckNeedUseAOE(25, 2, ConstValue.BardAOECount))
                return 3;
            
            

            var aura = Core.Me.GetAuraById(AurasDefine.BlastArrowReady);
            var buffTime = SpellsDefine.RagingStrikes.Cooldown.TotalMilliseconds;
            if (SpellsDefine.RagingStrikes.IsReady())
                buffTime = 0;

            if (DataBinding.Instance.EarlyDecisionMode)
                buffTime += SettingMgr.GetSetting<GeneralSettings>().ActionQueueMs;
            
            // Buff持续时间内需要补毒,那么立即打出去
            if (BardSpellHelper.IsTargetNeedIronJaws(Core.Me.CurrentTarget as Character, (int)aura.TimespanLeft.TotalMilliseconds))
                return 4;
            
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