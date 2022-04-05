using AEAssist.AI;

namespace AEAssist.Helper
{
    public static class SpellHistoryHelper
    {
        public static long GetLastSpellTime(uint SpellId)
        {
            AIRoot.Instance.SpellLastCastTime.TryGetValue(SpellId, out var time);
            return time;
        }
    }
}