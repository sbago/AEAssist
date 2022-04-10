using System;
using System.IO;
using System.Windows;
using AEAssist;

namespace AETriggers.TriggerModel
{
    public static class TriggerHelper
    {
        public static TriggerLine LoadTriggerLine(string path)
        {
            if (!File.Exists(path))
                return null;
            try
            {
                var line = MongoHelper.FromJson<TriggerLine>(File.ReadAllText(path));
                return line;
            }
            catch (Exception e)
            {
                LogHelper.Error(e.ToString());
                MessageBox.Show("加载失败: " + e);
                return null;
            }
        }

        public static void SaveTriggerLine(TriggerLine triggerLine, string path)
        {
            if (File.Exists(path))
                File.Delete(path);
            File.WriteAllText(path, MongoHelper.ToJson(triggerLine));
        }
    }
}