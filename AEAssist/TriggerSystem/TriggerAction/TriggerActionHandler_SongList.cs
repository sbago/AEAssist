using AEAssist.AI;
using AETriggers.TriggerModel;

namespace AEAssist.TriggerSystem.TriggerAction
{
    public class TriggerActionHandler_SongList : ATriggerActionHandler<TriggerAction_SongList>
    {
        protected override void Handle(TriggerAction_SongList t)
        {
            AIRoot.GetBattleData<BardBattleData>().nextSongList.Clear();
            AIRoot.GetBattleData<BardBattleData>().nextSongDuration.Clear();
            AIRoot.GetBattleData<BardBattleData>().nextSongList.AddRange(t.SongIndex);
            foreach (var v in t.Durations)
            {
                AIRoot.GetBattleData<BardBattleData>().nextSongDuration.Add(v*1000);   
            }
            LogHelper.Debug($"Set song list : Count :{AIRoot.GetBattleData<BardBattleData>().nextSongList.Count}");
        }
    }
}