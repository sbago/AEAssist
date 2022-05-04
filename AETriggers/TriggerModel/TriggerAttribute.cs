using System;

namespace AEAssist
{
    public class TriggerAttribute : Attribute
    {
        public string Name;

        public TriggerAttribute(string name)
        {
            Name = name;
        }
    }
}