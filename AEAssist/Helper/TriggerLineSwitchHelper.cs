using System.Collections.Generic;
using System.IO;
using System.Windows;
using AETriggers.TriggerModel;

namespace AEAssist.Helper
{
    public static class TriggerLineSwitchHelper
    {
        private static string Path = $@"{SettingMgr.SettingPath}\TriggerLine";

        public static Dictionary<(ushort zoneId, uint sub), TriggerLine> AllTriggerLines =
            new Dictionary<(ushort zoneId, uint sub), TriggerLine>();


        public static void LoadAll()
        {
            if (!Directory.Exists(Path))
                Directory.CreateDirectory(Path);
            AllTriggerLines.Clear();
            var files = Directory.GetFiles(Path, ".*json");

            if (files == null || files.Length == 0)
            {
                return;
            }

            foreach (var v in files)
            {

                var triggerLineRet = TriggerHelper.LoadTriggerLine(v);
                if (triggerLineRet.Item2 == null)
                {
                    MessageBox.Show($"File: {v} \n"+triggerLineRet.Item1);
                    AllTriggerLines.Clear();
                    return;
                }
            }
        }

        public static void ApplyTriggerLine(ushort zoneId,uint sub)
        {
            if (!SettingMgr.GetSetting<GeneralSettings>().AutoSwitchTriggerLine)
                return;
            var key = (zoneId, sub);
            if (!AllTriggerLines.TryGetValue(key, out var line))
            {
                return;
            }

            DataBinding.Instance.ChangeTriggerLine(line);
        }

    }
}