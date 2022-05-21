using System;

namespace AEAssist.TriggerCond
{
    [Trigger("EnemyInLOS")]
    public class TriggerCond_EnemyInLOS : ITriggerCond
    {
        public int delayTime;
        public string name;

        public void WriteFromJson(string[] values)
        {
            name = values[0];
            if (string.IsNullOrEmpty(name)) throw new Exception("is null!");

            if (!int.TryParse(values[1], out var delay)) throw new Exception($"{values[1]}Error!\n");
            if (delay < 0) throw new Exception("Must >=0 : " + delay);
            delayTime = delay;
        }

        public string[] Pack2Json()
        {
            return new string[]
            {
                name,
                delayTime.ToString()
            };
        }
    }
}