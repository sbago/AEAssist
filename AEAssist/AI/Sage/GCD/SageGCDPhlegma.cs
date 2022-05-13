using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;

namespace AEAssist.AI.Sage.GCD
{
    public class SageGcdPhlegma : IAIHandler
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
            //TODO:FIX ERROR Null refrence point
            if (DataBinding.Instance.UseAOE)
            {
                var aoeChecker = TargetHelper.CheckNeedUseAOE(12, 5, ConstValue.SageAOECount);
                if (aoeChecker)
                {
                    LogHelper.Info("Inside The AOE For sage Getting Phlegma");
                    var spellData = SageSpellHelper.GetPhlegma();
                    if (spellData == null)
                    {
                        LogHelper.Error("Failed to get spell returning null;"); 
                        return null;
                    }
                    LogHelper.Info("Doing Phlegma");
                    if (await spellData.DoGCD()) return spellData;
                }
            }
            
            var spell = SageSpellHelper.GetPhlegma();
            if (spell == null) return null;
            var ret = await spell.DoGCD();
            return ret ? spell : null;
        }
    }
}