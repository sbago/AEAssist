using AEAssist.AI;
using ff14bot.Objects;

namespace AEAssist.Helper
{
    // Time to kill
    public static class TTKHelper
    {
        public static bool IsTargetTTK(Character target,bool ignoreBossCheck = false)
        {
            return IsTargetTTK(target, SettingMgr.GetSetting<GeneralSettings>().TimeToKill_TimeInSec,ignoreBossCheck);
        }

        public static bool IsTargetTTK(Character target, int timeInSec,bool ignoreBossCheck)
        {
            if (!SettingMgr.GetSetting<GeneralSettings>().OpenTTK)
                return false;

            if (!ignoreBossCheck && target.IsBoss())
                return false;
            
            if (!TargetMgr.Instance.TargetStats.TryGetValue(target.ObjectId, out var stat)) return false;

            if (stat.DeathPrediction == 0) return false;

            var config = timeInSec * 1000;

            // LogHelper.Debug($"{target.ObjectId} Hp {target.CurrentHealth} DeathPre {stat.DeathPrediction} Config {config}");

            if (stat.DeathPrediction > config)
                return false;

            return true;
        }

        public static bool IsBossTTK(Character target)
        {
            if (!SettingMgr.GetSetting<GeneralSettings>().OpenTTK)
                return false;
            if (!target.IsBoss())
                return false;
                   
            if (!TargetMgr.Instance.TargetStats.TryGetValue(target.ObjectId, out var stat)) return false;

            if (stat.DeathPrediction == 0) return false;

            var config = 6000;

            // LogHelper.Debug($"{target.ObjectId} Hp {target.CurrentHealth} DeathPre {stat.DeathPrediction} Config {config}");

            if (stat.DeathPrediction > config)
                return false;

            return true;
        }
    }
}