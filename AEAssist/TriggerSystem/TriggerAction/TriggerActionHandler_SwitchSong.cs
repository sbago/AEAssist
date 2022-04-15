using System;
using AEAssist.AI;
using AEAssist.Define;
using AETriggers.TriggerModel;
using ff14bot.Managers;

namespace AEAssist.TriggerSystem.TriggerAction
{
    public class TriggerActionHandler_SwitchSong : ATriggerActionHandler<TriggerAction_SwitchSong>
    {
        protected override void Handle(TriggerAction_SwitchSong t)
        {
            switch ((ActionResourceManager.Bard.BardSong)t.index)
            {
                case ActionResourceManager.Bard.BardSong.MagesBallad:
                    AIRoot.Instance.BattleData.NextAbilitySpellId = SpellsDefine.MagesBallad.Id;
                    break;
                case ActionResourceManager.Bard.BardSong.ArmysPaeon:
                    AIRoot.Instance.BattleData.NextAbilitySpellId = SpellsDefine.ArmysPaeon.Id;
                    break;
                case ActionResourceManager.Bard.BardSong.WanderersMinuet:
                    AIRoot.Instance.BattleData.NextAbilitySpellId = SpellsDefine.TheWanderersMinuet.Id;
                    break;
            }
        }
    }
}