using System;
using System.IO;
using System.Windows;
using AEAssist;
using AETriggers.TriggerModel;
using Newtonsoft.Json;

namespace AETriggers.TriggerModel
{
    public static class TriggerHelper
    {
        private static JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings() { 
            TypeNameHandling = TypeNameHandling.All 
        }; 

        public static TriggerLine LoadTriggerLine(string path)
        {
            if (!File.Exists(path))
                return null;
            var str = File.ReadAllText(path);
            try
            {
                var line = JsonConvert.DeserializeObject<TriggerLine>(str,jsonSerializerSettings);
                return line;
            }
            catch (Exception e)
            {
                MessageBox.Show("加载失败: " + e.ToString());
                return null;
            }
        }

        public static void SaveTriggerLine(TriggerLine triggerLine, string path)
        {
            File.WriteAllText(path,JsonConvert.SerializeObject(triggerLine,jsonSerializerSettings));
        }
    }
}