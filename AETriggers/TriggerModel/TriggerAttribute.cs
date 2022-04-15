using System;

namespace AETriggers.TriggerModel
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