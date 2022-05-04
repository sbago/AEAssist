using AEAssist.AI;
using ff14bot.Objects;

namespace AEAssist.Helper
{
    public static class SpellHistoryHelper
    {
        public static long GetLastSpellTime(uint SpellId)
        {
            SpellHistoryMgr.Instance.SpellLastCastTime.TryGetValue(SpellId, out var time);
            return time;
        }

        public static int GetLastGCDIndex(uint SpellId)
        {
            SpellHistoryMgr.Instance.SpellLastCastGCDIndex.TryGetValue(SpellId, out var time);
            return time;
        }
        
        public static bool RecentlyUsed(this SpellData spellData, int span = 1000)
        {
            var time = GetLastSpellTime(spellData.Id);
            if (TimeHelper.Now() - time < span)
                return true;
            return false;
        }
    }
}