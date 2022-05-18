using System.Collections.Generic;
using System.Threading.Tasks;
using AEAssist.AI.Dancer.Ability;
using AEAssist.AI.Dancer.GCD;
using AEAssist.Helper;
using ff14bot.Enums;

namespace AEAssist.AI.Dancer
{
    [Job(ClassJobType.Dancer)]
    public class Dancer_AIPriority : IAIPriorityQueue
    {
        public List<IAIHandler> GCDQueue { get; } = new List<IAIHandler>()
        {
            new DancerGCD_StandardStep(),
            new DancerGCD_TechnicalStep(),
            new DancerGCD_BaseGCD()
        };

        public List<IAIHandler> AbilityQueue { get; } = new List<IAIHandler>()
        {
            new DancerAbility_DanceStep(),
        };
        public async Task<bool> UsePotion()
        {
            return await PotionHelper.ForceUsePotion(SettingMgr.GetSetting<GeneralSettings>().DexPotionId);
        }
    }
}