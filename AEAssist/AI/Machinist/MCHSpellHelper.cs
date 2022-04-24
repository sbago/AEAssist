using System;
using System.Diagnostics;
using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist.AI
{
    public static class MCHSpellHelper
    {
        public static SpellEntity GetSplitShot()
        {
            if (SpellsDefine.HeatedSplitShot.IsUnlock())
                return SpellsDefine.HeatedSplitShot;
            return SpellsDefine.SplitShot;
        }

        public static SpellEntity GetSlugShot()
        {
            if (SpellsDefine.HeatedSlugShot.IsUnlock())
                return SpellsDefine.HeatedSlugShot;
            return SpellsDefine.SlugShot;
        }
        
        public static SpellEntity GetCleanShot()
        {
            if (SpellsDefine.HeatedCleanShot.IsUnlock())
                return SpellsDefine.HeatedCleanShot;
            return SpellsDefine.CleanShot;
        }

        public static SpellEntity GetSpreadShot()
        {
            if (SpellsDefine.Scattergun.IsUnlock())
                return SpellsDefine.Scattergun;
            return SpellsDefine.SpreadShot;
        }

        public static async Task<SpellEntity> UseBaseComboGCD(GameObject target)
        {
            if (TargetHelper.CheckNeedUseAOE(target,12, 12, 3))
            {
                var aoeGCD = GetSpreadShot();
                if (await aoeGCD.DoGCD())
                {
                    AIRoot.GetBattleData<MCHBattleData>().ComboStages = MCHComboStages.SpreadShot;
                    return aoeGCD;
                }
            }

        

            switch (AIRoot.GetBattleData<MCHBattleData>().ComboStages)
            {
                case MCHComboStages.SlugShot:
                    var slugShot = GetSlugShot();
                    if (ActionManager.ComboTimeLeft > 0)
                    {
                        if (await slugShot.DoGCD())
                        {
                            AIRoot.GetBattleData<MCHBattleData>().ComboStages = MCHComboStages.CleanShot;
                            return slugShot;
                        }
                    }
            
                    break;
                case MCHComboStages.CleanShot:
                    var cleanShot = GetCleanShot();
                    if (ActionManager.ComboTimeLeft > 0)
                    {
                        if (await cleanShot.DoGCD())
                        {
                            AIRoot.GetBattleData<MCHBattleData>().ComboStages = MCHComboStages.SplitShot;
                            return cleanShot;
                        }
                    }
                    break;
            }
            var splitShot = GetSplitShot();
            if (await splitShot.DoGCD())
            {
                AIRoot.GetBattleData<MCHBattleData>().ComboStages = MCHComboStages.SlugShot;
                return splitShot;
            }
            
            return null;
        }

        public static SpellEntity GetAirAnchor()
        {
            if (SpellsDefine.AirAnchor.IsUnlock())
                return SpellsDefine.AirAnchor;
            if (SpellsDefine.HotShot.IsUnlock())
                return SpellsDefine.HotShot;
            return null;
        }
        public static SpellEntity GetReassembleGCD()
        {
            SpellEntity spell = null;
            if (SpellsDefine.AirAnchor.IsReady())
            {
                spell = SpellsDefine.AirAnchor;
            }
            else if (SpellsDefine.Drill.IsReady())
            {
                spell = SpellsDefine.Drill;
            }
            else if (SpellsDefine.ChainSaw.IsReady())
            {
                spell = SpellsDefine.ChainSaw;
            }

            return spell;
        }

        public static SpellEntity GetAutomatonQueen()
        {
            if (SpellsDefine.AutomationQueen.IsUnlock())
                return SpellsDefine.AutomationQueen;
            return SpellsDefine.RookAutoturret;
        }
        
        public static SpellEntity GetQueenOverdrive()
        {
            if (SpellsDefine.QueenOverdrive.IsUnlock())
                return SpellsDefine.QueenOverdrive;
            return SpellsDefine.RookOverdrive;
        }

        public static bool CheckReassmableGCD(int timeleft)
        {
            if (SpellsDefine.ChainSaw.IsUnlock() && SpellsDefine.ChainSaw.Cooldown.TotalMilliseconds < timeleft)
                return true;
            if (SpellsDefine.Drill.IsUnlock() && SpellsDefine.Drill.Cooldown.TotalMilliseconds < timeleft)
                return true;
            if (SpellsDefine.AirAnchor.IsUnlock() && SpellsDefine.AirAnchor.Cooldown.TotalMilliseconds < timeleft)
                return true;
            return false;
        }

        public static SpellEntity GetDrillIfWithAOE()
        {
            if (TargetHelper.CheckNeedUseAOE(Core.Me.CurrentTarget, 12, 12))
            {

                return SpellsDefine.Bioblaster;

            }
            return SpellsDefine.Drill;
        }

        public static SpellEntity GetUnderHyperChargeGCD()
        {
            if (SpellsDefine.AutoCrossbow.IsUnlock() && TargetHelper.CheckNeedUseAOE(12, 12))
            {
                return SpellsDefine.AutoCrossbow;
            }
            
            return SpellsDefine.HeatBlast;
        }
    }
}