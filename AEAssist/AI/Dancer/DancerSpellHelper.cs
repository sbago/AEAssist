using System;
using System.Linq;
using System.Threading.Tasks;
using AEAssist.AI.Dancer;
using AEAssist.Define;
using AEAssist.Helper;
using Buddy.Coroutines;
using ff14bot;
using ff14bot.Helpers;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist.AI.Sage
{
    public class DancerSpellHelper
    {
        // Cascade 瀑泻 ST1 Reverse Cascade 逆瀑泻
        // Fountain 喷泉 ST2 :Fountainfall 坠喷泉 
        // Windmill 风车 AOE1 Rising Windmill 升风车 
        // Bladeshower 落刃雨 AOE2 :Bloodshower 落血雨 
        private static async Task<SpellEntity> UseSingleCombo(GameObject target)
        {
            if (ActionManager.ComboTimeLeft > 0)
            {
                if (AIRoot.GetBattleData<DancerBattleData>().CurrCombo == DancerComboStages.Fountain)
                {
                    if (await SpellsDefine.Fountain.DoGCD())
                    {
                        AIRoot.GetBattleData<DancerBattleData>().CurrCombo = DancerComboStages.Cascade;
                        return SpellsDefine.InfernalSlice.GetSpellEntity();
                    }
                }
            }

            if (await SpellsDefine.Cascade.DoGCD())
            {
                AIRoot.GetBattleData<DancerBattleData>().CurrCombo = DancerComboStages.Fountain;
                return SpellsDefine.Cascade.GetSpellEntity();
            }

            return null;
        }

        private static async Task<SpellEntity> UseAOECombo(GameObject target)
        {
            if (AIRoot.GetBattleData<DancerBattleData>().CurrCombo != DancerComboStages.Bladeshower
                || ActionManager.ComboTimeLeft <= 0)
            {
                if (await SpellsDefine.Windmill.DoGCD())
                {
                    AIRoot.GetBattleData<DancerBattleData>().CurrCombo = DancerComboStages.Bladeshower;
                    return SpellsDefine.Windmill.GetSpellEntity();
                }
            }
            else if (await SpellsDefine.Bladeshower.DoGCD())
            {
                AIRoot.GetBattleData<DancerBattleData>().CurrCombo = DancerComboStages.Windmill;
                return SpellsDefine.Bladeshower.GetSpellEntity();
            }

            return null;
        }

        public static SpellEntity UseDanceStep()
        {
            try
            {
                switch (ActionResourceManager.Dancer.CurrentStep)
                {
                    case ActionResourceManager.Dancer.DanceStep.Finish:
                        if (Core.Me.HasAura(AurasDefine.StandardStep))
                        {
                            return SpellsDefine.DoubleStandardFinish.GetSpellEntity();

                        }
                        else
                        {
                            return SpellsDefine.QuadrupleTechnicalFinish.GetSpellEntity();
                        }

                    case ActionResourceManager.Dancer.DanceStep.Emboite:
                        return SpellsDefine.Emboite.GetSpellEntity();

                    case ActionResourceManager.Dancer.DanceStep.Entrechat:
                        return SpellsDefine.Entrechat.GetSpellEntity();

                    case ActionResourceManager.Dancer.DanceStep.Jete:
                        return SpellsDefine.Jete.GetSpellEntity();

                    case ActionResourceManager.Dancer.DanceStep.Pirouette:
                        return SpellsDefine.Pirouette.GetSpellEntity();
                }
            }
            catch
            {
                return null;
            }

            return null;
        }

        public static async Task<SpellEntity> BaseGCDCombo(GameObject target)
        {
            if (TargetHelper.CheckNeedUseAOE(target, 5, 5)) return await UseAOECombo(target);

            return await UseSingleCombo(target);
        }
    }
}