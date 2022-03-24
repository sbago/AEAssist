using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Buddy.Coroutines;
using ff14bot.Enums;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist.Core
{
    internal static class Casting
    {
        #region Variables
        public static bool CastingHeal;
        public static SpellData CastingSpell;
        public static SpellData LastSpell;
        public static bool LastSpellSucceeded;
        public static DateTime LastSpellTimeFinishedUtc;
        public static readonly Stopwatch LastSpellTimeFinishAge = new Stopwatch();
        public static GameObject LastSpellTarget;
        public static GameObject SpellTarget;
        public static TimeSpan SpellCastTime;
        public static bool DoHealthChecks;
        public static bool NeedAura;
        public static uint Aura;
        public static bool UseRefreshTime;
        public static int RefreshTime;
        public static readonly Stopwatch CastingTime = new Stopwatch();
        //public static bool CastingTankBuster;
        public static bool CastingGambit;
        //public static GameObject LastTankBusterTarget;
        //public static DateTime LastTankBusterTime;
        //public static SpellData LastTankBusterSpell;
        public static List<SpellCastHistoryItem> SpellCastHistory = new List<SpellCastHistoryItem>();
        #endregion
        
    }

    public class SpellCastHistoryItem
    {
        public SpellData Spell { get; set; }
        public GameObject SpellTarget { get; set; }
        public DateTime TimeCastUtc { get; set; }
        public DateTime TimeStartedUtc { get; set; }
        public double DelayMs { get; set; }

        public int AnimationLockRemainingMs
        {
            get
            {
                double timeSinceStartMs = DateTime.UtcNow.Subtract(TimeStartedUtc).TotalMilliseconds - DelayMs;
                return timeSinceStartMs > Globals.AnimationLockMs ? 0 : Globals.AnimationLockMs - (int)timeSinceStartMs;
            }
        }
    }
}