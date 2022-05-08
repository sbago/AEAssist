using System.Collections.Generic;
using System.Threading.Tasks;
using AEAssist.AI.BLM.GCD;
using AEAssist.Helper;
using ff14bot.Enums;

namespace AEAssist.AI.BLM
{
    [AIPriorityQueue(ClassJobType.BlackMage)]
    public class BLM_AIPriorityQueue : IAIPriorityQueue
    {
        public List<IAIHandler> GCDQueue { get; } = new List<IAIHandler>()
        {
            new BLM_BaseGCD()
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