using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Objects;

namespace AEAssist.AI
{
    public class BardGCD_BlastArrow : IAIHandler
    {
        public bool Check(SpellData lastSpell)
        {
            if (!Core.Me.HasAura(AurasDefine.BlastArrowReady))
                return false;
            return true;
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