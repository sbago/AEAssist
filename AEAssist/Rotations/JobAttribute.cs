using System;
using System.Windows.Forms.VisualStyles;
using ff14bot.Enums;

namespace AEAssist
{
    [AttributeUsage(AttributeTargets.Class,AllowMultiple = true)]
    public class JobAttribute : Attribute
    {
        public ClassJobType ClassJobType;

        public JobAttribute(ClassJobType classJobType)
        {
            ClassJobType = classJobType;
        }
    }
}