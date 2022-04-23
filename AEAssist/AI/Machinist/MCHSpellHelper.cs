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
        public static SpellData GetSplitShot()
        {
            if (SpellsDefine.HeatedSplitShot.IsUnlock())
                return SpellsDefine.HeatedSplitShot;
            return SpellsDefine.SplitShot;
        }

        public static SpellData GetSlugShot()
        {
            if (SpellsDefine.HeatedSlugShot.IsUnlock())
                return SpellsDefine.HeatedSlugShot;
            return SpellsDefine.SlugShot;
        }
        
        public static SpellData GetCleanShot()
        {
            if (SpellsDefine.HeatedCleanShot.IsUnlock())
                return SpellsDefine.HeatedCleanShot;
            return SpellsDefine.CleanShot;
        }

        public static SpellData GetSpreadShot()
        {
            if (SpellsDefine.Scattergun.IsUnlock())
                return SpellsDefine.Scattergun;
            return SpellsDefine.SpreadShot;
        }

        public static async Task<SpellData> UseBaseComboGCD(GameObject target)
        {
            if (TargetHelper.CheckNeedUseAOE(target,12, 12, 3))
            {
                var aoeGCD = GetSpreadShot();
                if (await SpellHelper.CastGCD(aoeGCD, target))
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
                        if (await SpellHelper.CastGCD(slugShot, target))
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
                        if (await SpellHelper.CastGCD(cleanShot, target))
                        {
                            AIRoot.GetBattleData<MCHBattleData>().ComboStages = MCHComboStages.SplitShot;
                            return cleanShot;
                        }
                    }
                    break;
            }
            var splitShot = GetSplitShot();
            if (await SpellHelper.CastGCD(splitShot, target))
            {
                AIRoot.GetBattleData<MCHBattleData>().ComboStages = MCHComboStages.SlugShot;
                return splitShot;
            }
            
            return null;
        }

        public static SpellData GetAirAnchor()
        {
            if (SpellsDefine.AirAnchor.IsUnlock())
                return SpellsDefine.AirAnchor;
            if (SpellsDefine.HotShot.IsUnlock())
                return SpellsDefine.HotShot;
            return null;
        }
        public static SpellData GetReassembleGCD()
        {
            SpellData spell = null;
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

        public static SpellData GetAutomatonQueen()
        {
            if (SpellsDefine.AutomationQueen.IsUnlock())
                return SpellsDefine.AutomationQueen;
            return SpellsDefine.RookAutoturret;
        }
        
        public static SpellData GetQueenOverdrive()
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

        public static SpellData GetDrillIfWithAOE()
        {
            if (TargetHelper.CheckNeedUseAOE(Core.Me.CurrentTarget, 12, 12))
            {

                return SpellsDefine.Bioblaster;

            }
            return SpellsDefine.Drill;
        }

        public static SpellData GetUnderHyperChargeGCD()
        {
            if (SpellsDefine.AutoCrossbow.IsUnlock() && TargetHelper.CheckNeedUseAOE(12, 12))
            {
                return SpellsDefine.AutoCrossbow;
            }
            
            return SpellsDefine.HeatBlast;
        }
    }
}