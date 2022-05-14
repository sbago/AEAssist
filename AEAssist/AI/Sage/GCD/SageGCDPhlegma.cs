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
            var currentDistance = Core.Me.CurrentTarget.Distance();
            if (currentDistance > 8.3)
            {
                LogHelper.Debug("Current Distance" + currentDistance + 
                                "is greater than 7 max range to use the ability..");
                return -6;
            }
            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            if (DataBinding.Instance.UseAOE)
            {
                var aoeChecker = TargetHelper.CheckNeedUseAOE(12, 5, ConstValue.SageAOECount);
                if (aoeChecker)
                {
                    var spellData = SageSpellHelper.GetPhlegma();
                    if (spellData == null)
                    {
                        LogHelper.Error("Failed to get spell returning null;"); 
                        return null;
                    }
                    LogHelper.Debug("Doing Phlegma AOE");
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