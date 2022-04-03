using System;

namespace AETriggers.TriggerModel
{
    public class TriggerAttribute : Attribute
    {
        public string Name;
        public string Remark;

        public TriggerAttribute(string name, string remark)
        {
            this.Name = name;
            this.Remark = remark;
        }
    }
}