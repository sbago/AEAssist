using System;
using PropertyChanged;

namespace AEAssist.TriggerAction
{
    [Trigger("CastGCD",ParamTooltip = "[SpellId]")]
    [AddINotifyPropertyChangedInterface]
    public class TriggerAction_CastGCD : ITriggerAction
    {
        public uint SpellId{ get; set; }

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