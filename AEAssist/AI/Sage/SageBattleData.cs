﻿using System.Collections.Generic;
using ff14bot;

namespace AEAssist.AI.Sage
{
    public class SageBattleData : IBattleData
    {
        public readonly Dictionary<uint, bool> lastEukrasianDosisWithObj = new Dictionary<uint, bool>();
        
        public bool IsTargetLastEukrasianDosis()
        {
            var targetId = Core.Me.CurrentTarget.ObjectId;
            lastEukrasianDosisWithObj.TryGetValue(targetId, out var ret);
            return ret;
        }
    }
}