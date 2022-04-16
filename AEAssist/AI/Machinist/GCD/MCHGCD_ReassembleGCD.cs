using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Objects;

namespace AEAssist.AI.MCH
{
    public class MCHGCD_ReassembleGCD : IAIHandler
    {
        public int Check(SpellData lastSpell)
        {
            var spell = MCHSpellHelper.GetReassembleGCD();
            if (spell == null)
                return -1;
            
            if (Core.Me.ContainMyAura(AurasDefine.Reassembled) || SpellsDefine.Reassemble.RecentlyUsed())
            {
                return 1;
            }

            return -2;
        }

        public async Task<SpellData> Run()
        {
            var spell = MCHSpellHelper.GetReassembleGCD();
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