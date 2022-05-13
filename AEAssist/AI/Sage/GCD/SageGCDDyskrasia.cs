using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;

namespace AEAssist.AI.Sage.GCD
{
    public class SageGCDDyskrasia : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            var phlegmaCheck = SageSpellHelper.GetDyskrasia();
            if (phlegmaCheck == null) return -1;
            if (Core.Me.CurrentTarget.Distance() != 0) return -1;
            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            var aoeChecker = TargetHelper.CheckNeedUseAOE(0, 5, ConstValue.SageAOECount);;
            if (!aoeChecker) return null;
            
            var spell = SageSpellHelper.GetDyskrasia();
            if (spell == null) return null;
            var ret = await spell.DoGCD();
            return ret ? spell : null;
        }
    }
}