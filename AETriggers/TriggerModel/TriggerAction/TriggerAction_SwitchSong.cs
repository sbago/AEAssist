using System;

namespace AEAssist.TriggerAction
{
    [Trigger("SwitchSong")]
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
    }
}