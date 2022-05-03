using System;

namespace AETriggers.TriggerModel
{
    [Trigger("EnemyCastSpell")]
    public class TriggerCond_EnemyCastSpell : ITriggerCond
    {
        public string spellName;
        public int delayTime;

        public void WriteFromJson(string[] values)
        {
            spellName = values[0];
            if (string.IsNullOrEmpty(spellName)) throw new Exception("Error!");
            if (!int.TryParse(values[1], out var va)) throw new Exception($"{values[1]}Error!\n");
            if (va < 0) throw new Exception("Must >= 0! :" + va);
            delayTime = va;
        }
    }
}