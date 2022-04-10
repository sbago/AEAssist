using System;

namespace AETriggers.TriggerModel
{
    public class TriggerAttribute : Attribute
    {
        public string Name;
        public string Remark;

        public TriggerAttribute(string name, string remark)
        {
            Name = name;
            Remark = remark;
        }
    }
}