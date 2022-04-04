using ff14bot.Managers;

namespace AEAssist.Define
{
    public class BardBattleData
    {
        public bool lastIronJawWithBuff;
        public long lastCastRagingStrikesTime;
        public long lastCastSongTime;
        
        #region NextSongs

        public ActionResourceManager.Bard.BardSong nextSong = ActionResourceManager.Bard.BardSong.None;
        public int nextSongDuration;

        #endregion
    }
}