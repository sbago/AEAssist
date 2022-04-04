using AEAssist.AI;
using AEAssist.DataBinding;
using AETriggers.TriggerModel;
using ff14bot.Managers;

namespace AEAssist.TriggerSystem.TriggerAction
{
    public class TriggerActionHandler_NextSong : ATriggerActionHandler<TriggerAction_NextSong>
    {
        protected override void Handle(TriggerAction_NextSong t)
        {
            AIRoot.Instance.BardBattleData.nextSong = (ActionResourceManager.Bard.BardSong) t.value;
            AIRoot.Instance.BardBattleData.nextSongDuration = t.Duration;
        }
    }
}