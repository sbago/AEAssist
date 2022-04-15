using System;

namespace AETriggers.TriggerModel
{
    [Trigger("CastGCD")]
    public class TriggerAction_CastGCD : ITriggerAction
    {
        public uint SpellId;
        public void WriteFromJson(string[] values)
        {
            if (!uint.TryParse(values[0], out var spell)) throw new Exception($"{values[0]}Error!");

            SpellId = spell;
        }
    }
}