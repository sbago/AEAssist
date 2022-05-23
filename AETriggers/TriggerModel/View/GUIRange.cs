using System;

namespace AEAssist.View
{
    [AttributeUsage(AttributeTargets.Property)]
    public class GUIIntRangeAttribute : Attribute
    {
        public int MinValue;
        public int MaxValue;

        public GUIIntRangeAttribute(int min ,int max)
        {
            this.MinValue = min;
            this.MaxValue = max;
        }
    }
    
    [AttributeUsage(AttributeTargets.Property)]
    public class GUIFloatRangeAttribute : Attribute
    {
        public float MinValue;
        public float MaxValue;

        public GUIFloatRangeAttribute(float min ,float max)
        {
            this.MinValue = min;
            this.MaxValue = max;
        }
    }
}