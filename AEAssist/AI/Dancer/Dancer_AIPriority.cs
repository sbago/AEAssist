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
            new DancerGCD_StarfallDance(),
            new DancerGCD_Tillana(),
            new DancerGCD_StandardStep(),
            new DancerGCD_TechnicalStep(),
            new DancerGCD_SaberDance(),
            new DancerGCD_Procs(),
            new DancerGCD_BaseGCD()
        };

        public List<IAIHandler> AbilityQueue { get; } = new List<IAIHandler>()
        {
            new DancerAbility_Devilment(),
            new DancerAbility_Flourish(),
            new DancerAbility_FanDance3(),
            new DancerAbility_FanDance(),
            
        };
        public async Task<bool> UsePotion()
        {
            return await PotionHelper.ForceUsePotion(SettingMgr.GetSetting<GeneralSettings>().DexPotionId);
        }
    }
}