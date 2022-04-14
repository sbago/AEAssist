using ff14bot.Objects;

namespace AEAssist.Helper
{
    public static class DotBlacklistHelper
    {
        public static bool IsBlackList(GameObject gameObject)
        {
            foreach (var v in SettingMgr.GetSetting<GeneralSettings>().DotBlacklist)
            {
                if (gameObject.Name.Contains(v))
                    return true;
            }

            return false;
        }
    }
}