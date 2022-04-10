using System;

namespace AETriggers.TriggerModel
{
    [Trigger("CastAbility", "插队使用指定能力技")]
    public class TriggerAction_CastAbility : ITriggerAction
    {
        public uint SpellId;

        public void WriteFromJson(string[] values)
        {
            if (!uint.TryParse(values[0], out var spell)) throw new Exception($"{values[0]}格式错误!");

            SpellId = spell;
        }
    }
}