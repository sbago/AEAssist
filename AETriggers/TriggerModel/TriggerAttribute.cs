using System;

namespace AEAssist
{
    public class TriggerAttribute : Attribute
    {
        public string Name;
        public string Tooltip;
        
        public bool NeedParams;
        public string ParamTooltip;
        public string Example;
        
        public TriggerAttribute(string name,string Tooltip = null,
            bool NeedParams = true,string ParamTooltip=null,string Example=null)
        {
            Name = name;
            this.Tooltip = Tooltip;

            this.NeedParams = NeedParams;
            this.ParamTooltip = ParamTooltip;
            this.Example = Example;
        }
    }
}