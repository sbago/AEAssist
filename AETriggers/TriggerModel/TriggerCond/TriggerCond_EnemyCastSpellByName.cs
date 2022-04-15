using System;

namespace AETriggers.TriggerModel
{
    [Trigger("EnemyCastSpellByName")]
    public class TriggerCond_EnemyCastSpellByName : ITriggerCond
    {
        public string spellName;

        public void WriteFromJson(string[] values)
        {
            spellName = values[0];
            if (string.IsNullOrEmpty(spellName)) throw new Exception("Error!");
        }
    }
}