using System.Threading.Tasks;
using AEAssist.Define;

namespace AEAssist.AI.Sage.GCD
{
    public class SageGcdToxikon : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            var toxikonCheck = SageSpellHelper.GetToxikon();
            if (toxikonCheck == null) return -1;
            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            var spell = SageSpellHelper.GetToxikon();
            if (spell == null) return null;
            var ret = await spell.DoGCD();
            return ret ? spell : null;
        }
    }
}