using System;
using ff14bot.Enums;

namespace AEAssist.AI
{
    public class AISpellQueueAttribute : Attribute
    {
        public ClassJobType ClassJobType;

        public AISpellQueueAttribute(ClassJobType classJobType)
        {
            ClassJobType = classJobType;
        }
    }

    public interface IAISpellQueue
    {
        bool Check();
    }
}