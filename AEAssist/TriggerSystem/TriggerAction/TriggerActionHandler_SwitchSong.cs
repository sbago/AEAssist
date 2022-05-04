using AEAssist.AI;
using AEAssist.Define;
using AEAssist.Helper;
using AEAssist.TriggerAction;
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
                    AEAssist.DataBinding.Instance.UseSong = true;
                else
                    AEAssist.DataBinding.Instance.UseSong = false;

                return;
            }

            switch ((ActionResourceManager.Bard.BardSong) t.index)
            {
                case ActionResourceManager.Bard.BardSong.MagesBallad:
                    AIRoot.GetBattleData<BattleData>().NextAbilitySpellId = SpellsDefine.MagesBallad.GetSpellEntity();
                    break;
                case ActionResourceManager.Bard.BardSong.ArmysPaeon:
                    AIRoot.GetBattleData<BattleData>().NextAbilitySpellId = SpellsDefine.ArmysPaeon.GetSpellEntity();
                    break;
                case ActionResourceManager.Bard.BardSong.WanderersMinuet:
                    AIRoot.GetBattleData<BattleData>().NextAbilitySpellId =
                        SpellsDefine.TheWanderersMinuet.GetSpellEntity();
                    break;
            }
        }
    }
}