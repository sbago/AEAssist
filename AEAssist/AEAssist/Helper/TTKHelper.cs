using ff14bot;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist.Helper
{
    // Time to kill
    public static class TTKHelper
    {
        public static bool IsTargetTTK(Character target)
        {
            if (!GeneralSettings.Instance.OpenTTK)
                return false;

            var hpLine = GeneralSettings.Instance.TimeToKill_HpLine;

            if (PartyManager.NumMembers <= 4)
            {
                hpLine /= 2;
            }

            if (target.CurrentHealth < hpLine)
                return true;

            // todo: 预计N秒内死亡
            return false;
        }
    }
}