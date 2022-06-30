using System.Collections.Generic;
using System.Threading.Tasks;
using AEAssist.AI.Samurai.Ability;
using AEAssist.AI.Samurai.GCD;
using AEAssist.Helper;
using ff14bot.Enums;

namespace AEAssist.AI.Samurai
{
    [Job(ClassJobType.Samurai)]
    public class Samurai_AIPriorityQueue : IAIPriorityQueue
    {
        public List<IAIHandler> GCDQueue { get; } = new List<IAIHandler>
        {
            // new SamuraiGCD_AoERotations(),
            // new SamuraiGCD_OddMinuteBurst(),
            // new SamuraiGCD_EvenMinutesBurst(),
            // new SamuraiGCD_Fillers(),
            new SamuraiGCD_CoolDownPhase(),
        };

        public List<IAIHandler> AbilityQueue { get; } = new List<IAIHandler>
        {
            new SamuraiAbility_Ikishoten(),
            new SamuraiAbility_Shoha(),
            new SamuraiAbility_TsubameGaeshi()
        };

        public Task<bool> UsePotion()
        {
            return PotionHelper.ForceUsePotion(SettingMgr.GetSetting<GeneralSettings>().StrPotionId);
        }
    }
}