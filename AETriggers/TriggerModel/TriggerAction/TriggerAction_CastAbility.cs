﻿using System;
using AEAssist.View;
using PropertyChanged;

namespace AEAssist.TriggerAction
{
    [Trigger("CastAbility 使用能力技",ParamTooltip = "[SpellId]")]
    [AddINotifyPropertyChangedInterface]
    public class TriggerAction_CastAbility : ITriggerAction
    {
        public uint SpellId{ get; set; }

        [GUIIntRange(0,3)]
        [GUIToolTip("0: DefaultByCode 1: Self 2: Target 3: Target's Target \n 0: 默认 1: 自己 2: 目标 3: 目标的目标 ")]
        public int TargetType { get; set; }

        public void WriteFromJson(string[] values)
        {
            if (!uint.TryParse(values[0], out var spell)) throw new Exception($"{values[0]} Error!");

            SpellId = spell;
        }

        public string[] Pack2Json()
        {
            return new string[]
            {
                SpellId.ToString()
            };
        }

        public void Check()
        {
            
        }
    }
}