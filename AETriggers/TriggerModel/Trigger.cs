using System.Collections.Generic;

namespace AEAssist
{
    public class Trigger
    {
        public string Id;
        public List<ITriggerAction> TriggerActions = new List<ITriggerAction>();
        public List<ITriggerCond> TriggerConds = new List<ITriggerCond>();
    }
}