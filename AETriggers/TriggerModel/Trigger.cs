using System.Collections.Generic;

namespace AETriggers.TriggerModel
{
    public class Trigger
    {
        public List<ITriggerCond> TriggerConds = new List<ITriggerCond>();
        public List<ITriggerAction> TriggerActions = new List<ITriggerAction>();
    }
}