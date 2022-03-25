using System;
using System.Linq;
using ff14bot.Managers;

namespace AEAssist.Define
{
    internal static class Globals
    {
        public static bool InParty => PartyManager.IsInParty;
        public static bool PartyInCombat => ff14bot.Core.Me.InCombat || Combat.Enemies.Any(/*r => r.TaggerType == 2*/);
        public static bool InGcInstance => RaptureAtkUnitManager.Controls.Any(r => r.Name == "GcArmyOrder");
        public static int AnimationLockMs = 700;
        public static TimeSpan AnimationLockTimespan = TimeSpan.FromMilliseconds(AnimationLockMs);
    }
}
