using ff14bot.Objects;

namespace AEAssist.Helper
{
    public static class DotBlacklistHelper
    {
        public static bool IsBlackList(Character gameObject)
        {
            foreach (var v in SettingMgr.GetSetting<GeneralSettings>().DotBlacklist)
            {
                LogHelper.Debug($"Check Dot blacklist: TargetName {gameObject.Name}  " +
                                $"NpcId: {gameObject.NpcId}" +
                                $" compare: {v}");
                if (gameObject.Name.Contains(v))
                    return true;
                if (gameObject.NpcId.ToString() == v)
                    return true;
            }

            return false;
        }
    }
}