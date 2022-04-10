using System;

namespace AETriggers.TriggerModel
{
    [Trigger(name: "GameLog", remark: "副本内台词/系统提示的监控")]
    public class TriggerCond_GameLog : ITriggerCond
    {
        public int MsgType;
        public string ContainValue;


        public void WriteFromJson(string[] values)
        {
            if (!int.TryParse(values[0], out var msgtype))
            {
                throw new Exception($"{values[0]} 格式错误!");
            }

            this.MsgType = msgtype;
            this.ContainValue = values[1];
        }
    }
}