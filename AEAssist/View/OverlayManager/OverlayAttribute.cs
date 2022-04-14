using System;
using ff14bot.Enums;

namespace AEAssist.View
{
    public class OverlayAttribute : Attribute
    {
        public ClassJobType ClassJobType;

        public OverlayAttribute(ClassJobType classJobType)
        {
            this.ClassJobType = classJobType;
        }
    }
}