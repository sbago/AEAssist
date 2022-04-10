using System;

namespace AETriggers.TriggerModel
{
    [Trigger(name: "NextSong", remark: "设置下一首歌")]
    public class TriggerAction_NextSong : ITriggerAction
    {
        public int value;
        public int Duration;

        public void WriteFromJson(string[] values)
        {
            if (!int.TryParse(values[0], out var va))
            {
                throw new Exception($"{values[0]}格式错误!\n");
            }

            if (va < 0 || va > 3)
            {
                throw new Exception($"{values[0]}超出限定值!\n");
            }

            this.value = va;

            if (!int.TryParse(values[1], out var dura))
            {
                throw new Exception($"{values[1]}格式错误!\n");
            }

            if (dura < 0 || dura > 45000)
            {
                throw new Exception($"{values[1]}超出限定值!\n");
            }

            this.Duration = dura;
        }
    }
}