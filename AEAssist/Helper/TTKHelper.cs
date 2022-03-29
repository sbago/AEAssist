using AEAssist.AI;
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
            return IsTargetTTK(target,SettingMgr.GetSetting<GeneralSettings>().TimeToKill_TimeInSec);
        }
        
        public static bool IsTargetTTK(Character target, int timeInSec)
        {
            if (!SettingMgr.GetSetting<GeneralSettings>().OpenTTK)
                return false;

            if (!TargetMgr.Instance.TargetStats.TryGetValue(target.ObjectId,out var stat))
            {
                return false;
            }

            if (stat.DeathPrediction == 0)
            {
                return false;
            }

            var config = timeInSec * 1000;

            // LogHelper.Debug($"{target.ObjectId} Hp {target.CurrentHealth} DeathPre {stat.DeathPrediction} Config {config}");
            
            if (stat.DeathPrediction > config)
                return false;
            
            return true;
        }
    }
}