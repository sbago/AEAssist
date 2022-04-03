namespace AETriggers.TriggerModel
{
    [Trigger(name:"GameLog",remark:"一般用于副本内Boss/NPC说的话,或者系统提示语的监控")]
    public class TriggerCond_GameLog : ITriggerCond
    {
        public int MsgType;
        public string ContainValue;
        

        public void WriteFromJson(string[] values)
        {
            throw new System.NotImplementedException();
        }
    }
}