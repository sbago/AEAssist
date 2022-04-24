using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Objects;

namespace AEAssist.AI.Reaper
{
    // 近战之外的范围的GCD
    public class ReaperGCD_PullRangeGCD : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            if (Core.Me.CanAttackTargetInRange(Core.Me.CurrentTarget, 6))
                return -1;
            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            var spell = SpellsDefine.Harpe;
            if (SpellsDefine.HarvestMoon.IsUnlock() && Core.Me.HasAura(AurasDefine.Soulsow))
                spell = SpellsDefine.HarvestMoon;
            else if (!DataBinding.Instance.UseHarpe) return null;

            if (await spell.DoGCD()) return spell;

            return null;
        }
    }
}