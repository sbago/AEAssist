﻿using AEAssist.AI;
using AEAssist.Define;
using AEAssist.TriggerAction;
using ff14bot;
using ff14bot.Objects;

namespace AEAssist.TriggerSystem.TriggerAction
{
    public class TriggerActionHandler_CastAbility : ATriggerActionHandler<TriggerAction_CastAbility>
    {
        protected override void Handle(TriggerAction_CastAbility t)
        {
            switch (t.TargetType)
            {
                case 0:
                    AIRoot.GetBattleData<BattleData>().NextAbilitySpellId = new SpellEntity(t.SpellId);
                    break;
                case 1:
                    AIRoot.GetBattleData<BattleData>().NextAbilitySpellId = new SpellEntity(t.SpellId,SpellTargetType.Self);
                    break;
                case 2:
                    AIRoot.GetBattleData<BattleData>().NextAbilitySpellId = new SpellEntity(t.SpellId,SpellTargetType.CurrTarget);
                    break;
                case 3:
                    var currTar = Core.Me.CurrentTarget as BattleCharacter;
                    if (currTar == null || currTar.TargetCharacter == null)
                        break;
                    var tt = currTar.TargetCharacter as BattleCharacter;
                    if(tt == null)
                        break;
                    AIRoot.GetBattleData<BattleData>().NextAbilitySpellId = new SpellEntity(t.SpellId,tt);
                    break;
            }
        }
    }
}