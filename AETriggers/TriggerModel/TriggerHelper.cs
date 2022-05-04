using System;
using System.IO;
using System.Windows;
using AEAssist;

namespace AETriggers.TriggerModel
{
    public static class TriggerHelper
    {
        public static (string,TriggerLine) LoadTriggerLine(string path)
        {
            if (!File.Exists(path))
                return (null,null);
            try
            {
                var line = MongoHelper.FromJson<TriggerLine>(File.ReadAllText(path));
                if (line.ConfigVersion < TriggerLine.CurrConfigVersion)
                {
                    line = null;
                    return ("Loading failed: old version!", line);
                }

                return  ("Loading success!", line);;
            }
            catch (Exception e)
            {
                LogHelper.Error(e.ToString());
                return ("Loading failed: Exception:\n " + e,null);
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