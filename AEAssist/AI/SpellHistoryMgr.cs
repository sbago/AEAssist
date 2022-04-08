

using System.Collections.Generic;

namespace AEAssist.AI
{
    public struct SpellHistory
    {
        public uint SpellId;
        public long CastTime;
        public string Name;
    }
    public class SpellHistoryMgr
    {
        public static SpellHistoryMgr Instance = new SpellHistoryMgr();
        public Queue<SpellHistory> GCDSpellHistory = new Queue<SpellHistory>();
        public Queue<SpellHistory> AbilitySpellHistory = new Queue<SpellHistory>();
        public Dictionary<uint, long> SpellLastCastTime = new Dictionary<uint, long>();

        public void Clear()
        {
            GCDSpellHistory.Clear();
            AbilitySpellHistory.Clear();
            SpellLastCastTime.Clear();
        }

        public void AddGCDHistory(SpellHistory ret)
        {
            GCDSpellHistory.Enqueue(ret);
            SpellLastCastTime[ret.SpellId] = ret.CastTime;
        }
        
        public void AddAbilityHistory(SpellHistory ret)
        {
            AbilitySpellHistory.Enqueue(ret);
            SpellLastCastTime[ret.SpellId] = ret.CastTime;
        }
        
        public void CheckIfNeedClearHistory()
        {
            while (GCDSpellHistory.Count >= 50)
            {
                GCDSpellHistory.Dequeue();
            }
            while (AbilitySpellHistory.Count >= 50)
            {
                AbilitySpellHistory.Dequeue();
            }
        }
    }
}