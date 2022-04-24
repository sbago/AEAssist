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
            if (t.index <= 0)
            {
                if (t.index == 0)
                {
                    DataBinding.Instance.UseSong = true;
                }
                else
                {
                    DataBinding.Instance.UseSong = false;
                }

                return;
            }

            switch ((ActionResourceManager.Bard.BardSong)t.index)
            {
                case ActionResourceManager.Bard.BardSong.MagesBallad:
                    AIRoot.GetBattleData<BattleData>().NextAbilitySpellId = SpellsDefine.MagesBallad;
                    break;
                case ActionResourceManager.Bard.BardSong.ArmysPaeon:
                    AIRoot.GetBattleData<BattleData>().NextAbilitySpellId = SpellsDefine.ArmysPaeon;
                    break;
                case ActionResourceManager.Bard.BardSong.WanderersMinuet:
                    AIRoot.GetBattleData<BattleData>().NextAbilitySpellId = SpellsDefine.TheWanderersMinuet;
                    break;
            }
        }
    }
}