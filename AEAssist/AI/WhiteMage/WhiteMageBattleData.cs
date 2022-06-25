using System.Collections.Generic;
using ff14bot;

namespace AEAssist.AI.WhiteMage
{
    public class WhiteMageBattleData : IBattleData
    {
        public readonly Dictionary<uint, bool> lastAeroWithObj = new Dictionary<uint, bool>();

        public bool IsTargetLastAero()
        {
            var targetId = Core.Me.CurrentTarget.ObjectId;
            lastAeroWithObj.TryGetValue(targetId, out var ret);
            return ret;
        }
    }
}
