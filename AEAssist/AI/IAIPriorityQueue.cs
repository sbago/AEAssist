using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ff14bot.Enums;

namespace AEAssist.AI
{
    public class AIPriorityQueueAttribute : Attribute
    {
        public ClassJobType ClassJobType;

        public AIPriorityQueueAttribute(ClassJobType classJobType)
        {
            ClassJobType = classJobType;
        }
    }

    public interface IAIPriorityQueue
    {
        List<IAIHandler> GCDQueue { get; }

        List<IAIHandler> AbilityQueue { get; }

        Task<bool> UsePotion();
    }
}