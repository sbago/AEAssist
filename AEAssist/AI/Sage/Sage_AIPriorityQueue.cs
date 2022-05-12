using System.Collections.Generic;
using System.Threading.Tasks;
using AEAssist.AI.Sage.Ability;
using AEAssist.AI.Sage.GCD;
using AEAssist.Helper;
using ff14bot.Enums;

namespace AEAssist.AI.Sage
{
    [Job(ClassJobType.Sage)]
    public class Sage_AIPriorityQueue : IAIPriorityQueue
    {
        public List<IAIHandler> GCDQueue { get; } = new List<IAIHandler>()
        {
            new SageGCDDot(),
            new SageBaseGCD(),
            new SageGCDPhlegma(),
            new SageGCDToxikon(),
        };

        public List<IAIHandler> AbilityQueue { get; } = new List<IAIHandler>()
        {
         new SageAbilityLucidDreaming(),
        };
        public async Task<bool> UsePotion()
        {
            return await PotionHelper.ForceUsePotion(SettingMgr.GetSetting<GeneralSettings>().MindPotionId);
        }
    }
}