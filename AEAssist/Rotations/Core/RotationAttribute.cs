using System;
using ff14bot.Enums;

namespace AEAssist.Rotations.Core
{
    public class RotationAttribute : Attribute
    {
        public ClassJobType ClassJobType;

        public RotationAttribute(ClassJobType classJobType)
        {
            ClassJobType = classJobType;
        }
    }
}