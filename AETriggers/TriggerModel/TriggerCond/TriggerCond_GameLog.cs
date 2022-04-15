using System;

namespace AETriggers.TriggerModel
{
    [Trigger("GameLog")]
    public class TriggerCond_GameLog : ITriggerCond
    {
        public string ContainValue;
        public int MsgType;


        public void WriteFromJson(string[] values)
        {
            if (!int.TryParse(values[0], out var msgtype)) throw new Exception($"{values[0]} Error!");

            MsgType = msgtype;
            ContainValue = values[1];
        }
    }
}