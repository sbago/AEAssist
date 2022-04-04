using System.Collections.Generic;
using System.Threading.Tasks;
using AEAssist.AI;
using AEAssist.AI.Reaper.Ability;
using AEAssist.AI.Reaper.GCD;
using ff14bot.Enums;
using ff14bot.Objects;

namespace AEAssist.Define
{
    public static class ReaperAIHandlers
    {
        public static List<IAIHandler> AI_GCDs = new List<IAIHandler>()
        {
            new ReaperGCD_PullRangeGCD(),
            new ReaperGCD_ShadowOfDeath(),
            new ReaperGCD_EnshroudGCD(),
            new ReaperGCD_PlentifulHarvest(),
            new ReaperGCD_Gibbit_Gallows(),
            new ReaperGCD_SoulSlice(),
            new ReaperGCD_BaseGCDCombo()
        };

        public static List<IAIHandler> AI_Abilitys = new List<IAIHandler>()
        {
            new ReaperAbility_ArcaneCircle(),
            new ReaperAbility_Lemure(),
            new ReaperAbility_UsePotion(),
            new ReaperAbility_Enshroud(),
            new ReaperAbility_Gluttony(),
            new ReaperAbility_BloodStalk(),
        };

        public static async Task<SpellData> HandleGCD(SpellData lastGCD)
        {
            foreach (var v in AI_GCDs)
            {
                if (v.Check(lastGCD))
                {
                    return await v.Run();
                }
            }
            return null;
        }

        public static async Task<SpellData> HandleAbility(SpellData lastAbility)
        {

            foreach (var v in AI_Abilitys)
            {
                if (v.Check(lastAbility))
                {
                    return await v.Run();
                }
            }

            return null;
        }
    }
}