using System;

namespace AEAssist.TriggerAction
{
    [Trigger("LockSpell",Tooltip = "whether to use specify spell",
        ParamTooltip = "[SpellId],[1/0=lock/unlock]",
        Example = "12345,1")]
    public class TriggerAction_LockSpell : ITriggerAction
    {
        public bool Lock;
        public uint SpellId;

        public void WriteFromJson(string[] values)
        {
            if (!uint.TryParse(values[0], out var spell)) throw new Exception($"{values[0]}Error!");
            if (!int.TryParse(values[1], out var lockValue)) throw new Exception($"{values[1]}Error!");
            SpellId = spell;
            Lock = lockValue == 1;
        }

        public string[] Pack2Json()
        {
            return new string[]
            {
                SpellId.ToString(),
                Lock ? "1" : "0"
            };
        }
    }
}