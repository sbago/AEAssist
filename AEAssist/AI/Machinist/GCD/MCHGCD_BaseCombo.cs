using System.Threading.Tasks;
using ff14bot;
using ff14bot.Objects;

namespace AEAssist.AI.MCH
{
    public class MCHGCD_BaseCombo : IAIHandler
    {
        public int Check(SpellData lastSpell)
        {
            return 0;
        }

        public Task<SpellData> Run()
        {
            return MCHSpellHelper.UseBaseComboGCD(Core.Me.CurrentTarget);
        }
    }
}