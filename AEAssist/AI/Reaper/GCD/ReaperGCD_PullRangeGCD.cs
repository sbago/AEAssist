using System.Threading.Tasks;
using AEAssist.DataBinding;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Objects;

namespace AEAssist.AI.Reaper.GCD
{
    // 近战之外的范围的GCD
    public class ReaperGCD_PullRangeGCD : IAIHandler
    {
        public bool Check(SpellData lastSpell)
        {
            if (Core.Me.CanAttackTargetInRange(Core.Me.CurrentTarget,6))
                return false;
            return true;
        }

        public async Task<SpellData> Run()
        {
            var spell = SpellsDefine.Harpe;
            if (SpellsDefine.HarvestMoon.IsUnlock() && Core.Me.HasAura(AurasDefine.Soulsow))
            {
                spell = SpellsDefine.HarvestMoon;
            }
            else if(!BaseSettings.Instance.UseHarpe)
            {
                return null;
            }

            if (await SpellHelper.CastGCD(spell, Core.Me.CurrentTarget))
            {
                return spell;
            }

            return null;
        }
    }
}