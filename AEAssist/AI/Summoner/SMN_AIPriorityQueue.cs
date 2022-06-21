using System.Collections.Generic;
using System.Threading.Tasks;
using AEAssist.AI.Bard.Ability;
using AEAssist.AI.BlackMage.Ability;
using AEAssist.AI.BlackMage.GCD;
using AEAssist.Helper;
using ff14bot.Enums;

namespace AEAssist.AI.Summoner
{
    [Job(ClassJobType.Summoner)]
    public class SMN_AIPriorityQueue : IAIPriorityQueue
    {
        public List<IAIHandler> GCDQueue { get; } = new List<IAIHandler>()
        {
            new SMN_GCD_Base()
        };

        public List<IAIHandler> AbilityQueue { get; } = new List<IAIHandler>()
        {
        };
        public Task<bool> UsePotion()
        {
            return Task.FromResult(false);
        }
    }
}