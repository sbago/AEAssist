using System;

namespace AETriggers.TriggerModel
{
    [Trigger("GameLog", "副本内台词/系统提示的监控")]
    public class TriggerCond_GameLog : ITriggerCond
    {
        public string ContainValue;
        public int MsgType;


        public void WriteFromJson(string[] values)
        {
            if (!int.TryParse(values[0], out var msgtype)) throw new Exception($"{values[0]} 格式错误!");

            MsgType = msgtype;
            ContainValue = values[1];
        }
    }
}