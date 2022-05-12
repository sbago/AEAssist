using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;

namespace AEAssist.AI.Sage.GCD
{
    public class SageBaseGCD : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            // don't cast dosis when moving, instead going to cast other spells.
            if (MovementManager.IsMoving) return -1;
            return 0;
        }

        public async  Task<SpellEntity> Run()
        {
            if (DataBinding.Instance.UseAOE)
            {
                var aoeCount = TargetHelper.GetNearbyEnemyCount(Core.Me.CurrentTarget, 12, 5);
                if (aoeCount >= ConstValue.SageAOECount)
                {
                    var spellData = SageSpellHelper.GetPhlegma();
                    if (await spellData.DoGCD()) return spellData;
                }
                aoeCount = TargetHelper.GetNearbyEnemyCount(Core.Me.CurrentTarget, 0, 5);
                if (aoeCount >= ConstValue.SageAOECount)
                {
                    var spellData = SageSpellHelper.GetDyskrasia();
                    if (await spellData.DoGCD()) return  spellData;
                }
            }
            {
                var spellData = SageSpellHelper.GetBaseGCD();
                if (spellData == null)
                    return null;
                if (await spellData.DoGCD())
                    return spellData;
            }
            return null;
        }
    }
}