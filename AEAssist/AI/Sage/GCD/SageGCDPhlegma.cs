﻿using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;

namespace AEAssist.AI.Sage.GCD
{
    public class SageGcdPhlegma : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            var phlegmaCheck = SageSpellHelper.GetPhlegma();
            if (phlegmaCheck == null) return -1;
            if (!ActionManager.CanCastOrQueue(phlegmaCheck.SpellData, Core.Me.CurrentTarget))
            {
                LogHelper.Debug("Can't Cast Phlegma distance maybe too much?");
                return -6;
            }
            var phlegmaCharges = DataManager.GetSpellData(SpellsDefine.Phlegma).Charges;
            var phlegmaChargesII = DataManager.GetSpellData(SpellsDefine.PhlegmaII).Charges;
            var phlegmaChargesIII = DataManager.GetSpellData(SpellsDefine.PhlegmaIII).Charges;
            
            LogHelper.Debug("Current Phlegma Charge is: " + phlegmaChargesIII);

            if (phlegmaCharges == 0 || phlegmaChargesII == 0 || phlegmaChargesIII == 0)
            {
                LogHelper.Debug("Phlegma has 0 charges meaning is not ready so skip it.");
                return -1;
            }

            // If we are not moving check how many charges left for phlegma; don't waste it keep it for movement.
            if (MovementManager.IsMoving) return 0;
            if (!(phlegmaCharges < 2) && !(phlegmaChargesII < 2) && !(phlegmaChargesIII < 2)) return 0;
            LogHelper.Debug("Not wasting Phlegma while standing still saving it for movement cast.");
            return -1;
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