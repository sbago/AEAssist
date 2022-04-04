using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Objects;

namespace AEAssist.AI
{
    public class BardGCD_QuickNock : IAIHandler
    {
        public int Check(SpellData lastSpell)
        {
            var spell = BardSpellHelper.GetQuickNock();
            if (spell == null)
                return -1;
            if (TargetHelper.CheckNeedUseAOE(12, 12, ConstValue.BardAOECount))
                return 0;
            return -2;
        }

        public async Task<SpellData> Run()
        {
            var spell = BardSpellHelper.GetQuickNock();
            if (spell == null)
                return null;
            var ret = await SpellHelper.CastGCD(spell, Core.Me.CurrentTarget);
            if (ret)
                return spell;
            return null;
        }
    }
}