using System;
using ff14bot.Enums;

namespace AEAssist.View.OverlayManager
{
    public class OverlayAttribute : Attribute
    {
        public ClassJobType ClassJobType;

        public OverlayAttribute(ClassJobType classJobType)
        {
            ClassJobType = classJobType;
        }
    }
}