using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Objects;

namespace AEAssist.AI.Reaper.GCD
{
    public class ReaperGCD_Gibbit_Gallows : IAIHandler
    {
        public int Check(SpellData lastSpell)
        {
            if (!SpellsDefine.Gibbet.IsUnlock()) return -1;

            if (Core.Me.HasAura(AurasDefine.SoulReaver))
                return 0;
            return -2;
        }

        public async Task<SpellData> Run()
        {
            var spell = ReaperSpellHelper.Gibbit_Gallows(Core.Me.CurrentTarget);
            if (spell == null)
                return null;
            if (await SpellHelper.CastGCD(spell, Core.Me.CurrentTarget)) return spell;

            return null;
        }
    }
}