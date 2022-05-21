using System;

namespace AEAssist.TriggerAction
{
    [Trigger("NextSong")]
    public class TriggerAction_NextSong : ITriggerAction
    {
        public int Duration;
        public int value;

        public void WriteFromJson(string[] values)
        {
            if (!int.TryParse(values[0], out var va)) throw new Exception($"{values[0]}Error!\n");

            if (va < 0 || va > 3) throw new Exception($"{values[0]} Out of range!\n");

            value = va;

            if (!int.TryParse(values[1], out var dura)) throw new Exception($"{values[1]}Error!\n");

            if (dura < 0 || dura > 45) throw new Exception($"{values[1]} Out of range!\n");

            Duration = dura;
        }

        public string[] Pack2Json()
        {
            return new string[]
            {
                value.ToString(),
                Duration.ToString()
            };
        }
    }
}