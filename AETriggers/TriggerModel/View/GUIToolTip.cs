using System;

namespace AEAssist.View
{
    [AttributeUsage(AttributeTargets.Property)]
    public class GUIToolTipAttribute : Attribute
    {
        public string tip;
        public GUIToolTipAttribute(string tip)
        {
            this.tip = tip;
        }
    }
}