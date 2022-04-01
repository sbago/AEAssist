using System;
using System.IO;
using AETriggers.TriggerModel;
using ff14bot.Enums;
using Newtonsoft.Json;

namespace AETriggers.TriggerModel
{
    public static class TriggerHelper
    {
        public static void CreateTemplateFile(string dirPath)
        {
            if (!Directory.Exists(dirPath))
                Directory.CreateDirectory(dirPath);

            var TriggerLine = new TriggerLine
            {
                Version = "1.0",
                Author = "AE",
                TargetDuty = 0,
                TargetJob = ClassJobType.Adventurer,
            };
            {
                foreach (var v in TriggerMgr.Instance.AllCondType)
                {
                    var trigger = new Trigger();
                    trigger.TriggerCond = Activator.CreateInstance(v) as ITriggerCond;
                    TriggerLine.Triggers.Add(trigger);
                }
                foreach (var v in TriggerMgr.Instance.AllActionType)
                {
                    var trigger = new Trigger();
                    trigger.TriggerAction = Activator.CreateInstance(v) as ITriggerAction;
                    TriggerLine.Triggers.Add(trigger);
                }

            }
            var filePath = dirPath + "/TriggerLineTemplate.json";
            File.WriteAllText(filePath,JsonConvert.SerializeObject(TriggerLine));

        }

        public static TriggerLine LoadTriggerLine(string path)
        {
            if (!File.Exists(path))
                return null;
            var str = File.ReadAllText(path);
            try
            {
                var line = JsonConvert.DeserializeObject<TriggerLine>(str);
                return line;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}