using System;

namespace AETriggers.TriggerModel
{
    [Trigger("LockSpell")]
    public class TriggerAction_LockSpell : ITriggerAction
    {
        public uint SpellId;
        public bool Lock;
        public void WriteFromJson(string[] values)
        {
            if (!uint.TryParse(values[0], out var spell)) throw new Exception($"{values[0]}Error!");
            if (!int.TryParse(values[1], out var lockValue)) throw new Exception($"{values[1]}Error!");
            SpellId = spell;
            Lock = lockValue == 1;
        }
    }
}