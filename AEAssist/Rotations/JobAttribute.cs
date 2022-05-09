using System;
using ff14bot.Enums;

namespace AEAssist
{
    public class JobAttribute : Attribute
    {
        public ClassJobType ClassJobType;

        public JobAttribute(ClassJobType classJobType)
        {
            ClassJobType = classJobType;
        }
    }
}