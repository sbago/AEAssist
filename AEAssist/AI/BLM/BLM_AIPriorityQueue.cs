using System.Collections.Generic;
using System.Threading.Tasks;
using AEAssist.AI.Bard.Ability;
using AEAssist.AI.BLM.Ability;
using AEAssist.AI.BLM.GCD;
using AEAssist.Helper;
using ff14bot.Enums;

namespace AEAssist.AI.BLM
{
    [Job(ClassJobType.BlackMage)]
    public class BLM_AIPriorityQueue : IAIPriorityQueue
    {
        public List<IAIHandler> GCDQueue { get; } = new List<IAIHandler>()
        {
            new BlackMageGCD_Thunder(),
            new BlackMageGCD_Xenoglossy(),
            new BlackMageGCD_Fire3(),
            new BlackMageGCD_Fire4(),
            new BlackMageGCD_Blizzard4(),
            new BlackMageGCD_Paradox(),
            new BlackMageGCD_Despair(),
            new BlackMageGCD_Blizzard3(),
            new BlackMageGCD_UmbralSoul(),

        };

        public List<IAIHandler> AbilityQueue { get; } = new List<IAIHandler>()
        {
            new BlackMageAblity_Manafont(),
            new BlackMageAblity_Amplifier(),
            new BlackMageAblity_Triplecast(),
            new BlackMageAblity_Sharpcast(),
            new BlackMageAblity_Swiftcast(),
            new BlackMageAblity_Leylines(),
            new BlackMageAblity_Transpose(),
        };
        public Task<bool> UsePotion()
        {
            return Task.FromResult(false);
        }
    }
}