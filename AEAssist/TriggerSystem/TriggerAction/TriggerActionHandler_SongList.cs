using AEAssist.AI;
using AETriggers.TriggerModel;

namespace AEAssist.TriggerSystem.TriggerAction
{
    public class TriggerActionHandler_SongList : ATriggerActionHandler<TriggerAction_SongList>
    {
        protected override void Handle(TriggerAction_SongList t)
        {
            AIRoot.GetBattleData<BardBattleData>().nextSongQueue.Clear();
            AIRoot.GetBattleData<BardBattleData>().nextSongDuration.Clear();
            foreach (var v in t.SongIndex)
            {
                AIRoot.GetBattleData<BardBattleData>().nextSongQueue.Enqueue(v);   
            }
            foreach (var v in t.Durations)
            {
                AIRoot.GetBattleData<BardBattleData>().nextSongDuration.Enqueue(v*1000);   
            }
        }
    }
}