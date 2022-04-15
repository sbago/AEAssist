using AEAssist.AI;
using AETriggers.TriggerModel;

namespace AEAssist.TriggerSystem.TriggerAction
{
    public class TriggerActionHandler_SongList : ATriggerActionHandler<TriggerAction_SongList>
    {
        protected override void Handle(TriggerAction_SongList t)
        {
            AIRoot.Instance.BardBattleData.nextSongQueue.Clear();
            AIRoot.Instance.BardBattleData.nextSongDuration.Clear();
            foreach (var v in t.SongIndex)
            {
                AIRoot.Instance.BardBattleData.nextSongQueue.Enqueue(v);   
            }
            foreach (var v in t.Durations)
            {
                AIRoot.Instance.BardBattleData.nextSongDuration.Enqueue(v*1000);   
            }
        }
    }
}