namespace AETriggers.TriggerModel
{
    public class TriggerAction_SwitchBurst : ITriggerAction
    {
        public string CondName => "Burst";
        public string Remark => "是否允许爆发";

        public bool value;
        
        public bool Check()
        {
            return true;
        }
    }
}