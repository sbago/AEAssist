
using System;
using ff14bot.Enums;

namespace AEAssist.Opener
{
    public class OpenerAttribute : Attribute
    {
        public ClassJobType ClassJobType;
        public int Level;

        public OpenerAttribute(ClassJobType classJobType, int level)
        {
            ClassJobType = classJobType;
            Level = level;
        }
    }
}