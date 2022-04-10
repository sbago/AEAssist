using System.Collections.Generic;
using AEAssist.AI;
using ff14bot;
using ff14bot.Managers;

namespace AEAssist.Define
{
    public class BardBattleData
    {
        public Dictionary<uint, bool> lastIronJawWithBuffWithObj = new Dictionary<uint, bool>();
        public long lastCastSongTime;

        public bool IsTargetLastIronJawWithBuff()
        {
            var targetId = Core.Me.CurrentTarget.ObjectId;
            lastIronJawWithBuffWithObj.TryGetValue(targetId, out var ret);
            return ret;
        }

        #region NextSongs

        public ActionResourceManager.Bard.BardSong nextSong = ActionResourceManager.Bard.BardSong.None;
        public int nextSongDuration;

        #endregion
    }
}