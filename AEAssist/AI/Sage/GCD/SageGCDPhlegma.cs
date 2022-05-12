using System.Threading.Tasks;
using AEAssist.Define;
using ff14bot;

namespace AEAssist.AI.Sage.GCD
{
    public class SageGCDPhlegma : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            var phlegmaCheck = SageSpellHelper.GetPhlegma();
            if (phlegmaCheck == null) return -1;
            if (Core.Me.CurrentTarget.Distance() > 5) return -1;
            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            var spell = SageSpellHelper.GetPhlegma();
            if (spell == null) return null;
            var ret = await spell.DoGCD();
            return ret ? spell : null;
        }
    }
}