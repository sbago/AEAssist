using ff14bot.Helpers;

namespace AEAssist
{
    public static class LogHelper
    {
        public static void Debug(string msg)
        {
            Logging.Write($"[AEAssist] {msg}");
        }
    }
}