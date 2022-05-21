using System;

namespace AEAssist.TriggerAction
{
    [Trigger("SwitchSong",Tooltip = "Immediately switch the song. (1 for MB, 2 for AP, 3 for WM). -1=toggle off the song,0 =toggle on ")]
    public class TriggerAction_SwitchSong : ITriggerAction
    {
        public int index;

        public void WriteFromJson(string[] values)
        {
            if (!int.TryParse(values[0], out var index)) throw new Exception($"{values[0]} Error!");

            if (index < -1 || index > 3)
                throw new Exception($"{values[0]} <-1 or >3!");

            this.index = index;
        }
        
        public string[] Pack2Json()
        {
            return new string[]
            {
                index.ToString()
            };
        }
    }
}