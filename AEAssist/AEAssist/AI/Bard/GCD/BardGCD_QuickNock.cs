using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Objects;

namespace AEAssist.AI
{
    public class BardGCD_QuickNock : IAIHandler
    {
        public bool Check(SpellData lastSpell)
        {
            var spell = BardSpellEx.GetQuickNock();
            if (spell == null)
                return false;
            return TargetHelper.CheckNeedUseAOE(12, 12, ConstValue.BardAOECount);
        }

        public async Task<SpellData> Run()
        {
            var spell = BardSpellEx.GetQuickNock();
            if (spell == null)
                return null;
            var ret = await SpellHelper.CastGCD(spell, Core.Me.CurrentTarget);
            if (ret)
                return spell;
            return null;
        }
    }
}