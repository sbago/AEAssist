using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Objects;

namespace AEAssist.AI.Reaper.GCD
{
    public class ReaperGCD_SoulSlice : IAIHandler
    {
        public bool Check(SpellData lastSpell)
        {
            if (!SpellsDefine.SoulSlice.IsChargeReady())
                return false;
            return true;
        }

        public async Task<SpellData> Run()
        {
            SpellData spell = ReaperSpellHelper.CanUseSoulSlice_Scythe(Core.Me.CurrentTarget);
            if (spell == null)
                return null;
            if (await SpellHelper.CastGCD(spell, Core.Me.CurrentTarget))
            {
                return spell;
            }

            return null;
        }
    }
}