using System;
using ff14bot.Enums;

namespace AEAssist.AI
{
    public class AISpellQueueAttribute : Attribute
    {
        public ClassJobType ClassJobType;

        public AISpellQueueAttribute(ClassJobType classJobType)
        {
            this.ClassJobType = classJobType;
        }
    }

    public interface IAISpellQueue
    {
        bool Check();
        //todo: 如何根据当前情况计算技能队列?还是提前计算好?如何处理意外情况打断技能队列?
    }
}