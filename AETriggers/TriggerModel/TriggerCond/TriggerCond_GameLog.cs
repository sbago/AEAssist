namespace AETriggers.TriggerModel
{
    public class TriggerCond_GameLog : ITriggerCond
    {
        public string CondName => "GameLog";
        public string Remark => "一般用于副本内Boss/NPC说的话,或者系统提示语的监控";

        public int MsgType;
        public string ContainValue;
        
        public bool Check()
        {
            return true;
        }
    }
}