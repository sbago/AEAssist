using System.Threading.Tasks;
using AEAssist.Define;
using ff14bot;
using ff14bot.Objects;

namespace AEAssist.AI.MCH
{
    public class MCHGCD_BaseCombo : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            return 0;
        }

        public Task<SpellEntity> Run()
        {
            return MCHSpellHelper.UseBaseComboGCD(Core.Me.CurrentTarget);
        }
    }
}