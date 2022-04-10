using System.Collections.Generic;
using System.Threading.Tasks;
using AEAssist.AI;
using AEAssist.AI.Reaper.Ability;
using AEAssist.AI.Reaper.GCD;
using AEAssist.Helper;
using ff14bot.Enums;
using ff14bot.Objects;

namespace AEAssist.Define
{
    public class Reaper_AIPriorityQueue : IAIPriorityQueue
    {
        public List<IAIHandler> GCDQueue { get; } = new List<IAIHandler>()
        {
            new ReaperGCD_PullRangeGCD(),
            new ReaperGCD_ShadowOfDeath(),
            new ReaperGCD_EnshroudGCD(),
            new ReaperGCD_PlentifulHarvest(),
            new ReaperGCD_Gibbit_Gallows(),
            new ReaperGCD_SoulSlice(),
            new ReaperGCD_BaseGCDCombo()
        };

        public List<IAIHandler> AbilityQueue { get; } = new List<IAIHandler>()
        {
            new ReaperAbility_ArcaneCircle(),
            new ReaperAbility_Lemure(),
            new ReaperAbility_UsePotion(),
            new ReaperAbility_Enshroud(),
            new ReaperAbility_Gluttony(),
            new ReaperAbility_BloodStalk(),
            new ReaperAbility_TrueNorth()
        };

        public async Task<bool> UsePotion()
        {
            return await PotionHelper.ForceUsePotion(SettingMgr.GetSetting<ReaperSettings>().UsePotionId);
        }
    }
}