using ff14bot;
using ff14bot.Directors;
using ff14bot.Managers;

namespace AEAssist.Helper
{
    public static class DutyHelper
    {
        /// <summary>
        /// Provides Duty State information. InProgress, NotInDuty, NotStarted, and Ended.
        /// </summary>
        /// <returns></returns>
        public static States State()
        {
            // return early if we are in combat; ignore everything else.
            if (Core.Me.InCombat) return States.InProgress;

            if (DirectorManager.ActiveDirector == null) return States.NotInDuty;

            if (DirectorManager.ActiveDirector.DirectorType != DirectorType.InstanceContent) return States.NotInDuty;

            var instanceDirector = (InstanceContentDirector)DirectorManager.ActiveDirector;

            if (instanceDirector.InstanceEnded) return States.Ended;

            return instanceDirector.InstanceStarted ? States.InProgress : States.NotStarted;
        }

        public enum States
        {
            NotInDuty,
            NotStarted,
            InProgress,
            Ended
        }
    }
}