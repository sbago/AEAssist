using System;
using PropertyChanged;

namespace AEAssist.TriggerCond
{
    [Trigger("GameLog",Tooltip = "Specify string included in character lines or system prompts",
        ParamTooltip = "[MessageType(0=ignore)],[content],[Time in sec]",
        Example = "0,haha,0\n\t68,testStr,5")]
    [AddINotifyPropertyChangedInterface]
    public class TriggerCond_GameLog : ITriggerCond
    {
        public string ContainValue { get; set; }
        public int delayTime { get; set; }
        public int MsgType { get; set; }


        public void WriteFromJson(string[] values)
        {
            if (!int.TryParse(values[0], out var msgtype)) throw new Exception($"{values[0]} Error!");

            MsgType = msgtype;
            ContainValue = values[1];
            if (!int.TryParse(values[2], out var delay)) throw new Exception($"{values[2]}Error!\n");
            delayTime = delay;
        }

        public string[] Pack2Json()
        {
            return new string[]
            {
                MsgType.ToString(),
                ContainValue.ToString(),
                delayTime.ToString()
            };
        }
    }
}