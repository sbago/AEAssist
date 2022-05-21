using System;

namespace AEAssist.TriggerAction
{
    [Trigger("CastGCD",ParamTooltip = "[SpellId]")]
    public class TriggerAction_CastGCD : ITriggerAction
    {
        public uint SpellId;

        public void WriteFromJson(string[] values)
        {
            if (!uint.TryParse(values[0], out var spell)) throw new Exception($"{values[0]}Error!");

            SpellId = spell;
        }

        public string[] Pack2Json()
        {
            return new string[]
            {
                SpellId.ToString()
            };
        }
    }
}