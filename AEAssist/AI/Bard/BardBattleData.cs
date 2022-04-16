using System.Collections.Generic;
using AEAssist.AI;
using ff14bot;
using ff14bot.Managers;

namespace AEAssist.AI
{
    public class BardBattleData : IBattleData
    {
        public long lastCastSongTime;
        public Dictionary<uint, bool> lastIronJawWithBuffWithObj = new Dictionary<uint, bool>();

        public bool IsTargetLastIronJawWithBuff()
        {
            var targetId = Core.Me.CurrentTarget.ObjectId;
            lastIronJawWithBuffWithObj.TryGetValue(targetId, out var ret);
            return ret;
        }

        #region NextSongs

        public Queue<int> nextSongQueue = new Queue<int>();
        public Queue<int> nextSongDuration =new Queue<int>();

        #endregion
    }
}