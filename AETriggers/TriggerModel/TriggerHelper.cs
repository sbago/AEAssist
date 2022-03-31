using System;
using System.IO;
using AETriggers.TriggerModel.TriggerAction;
using Newtonsoft.Json;

namespace AETriggers.TriggerModel
{
    public static class TriggerHelper
    {
        public static void CreateTemplateFile(string dirPath)
        {
            if (!Directory.Exists(dirPath))
                Directory.CreateDirectory(dirPath);

            var TriggerLine = new TriggerLine();
            {
                var trigger = new Trigger();

                foreach (var v in TriggerMgr.Instance.AllCondType)
                {
                    trigger.TriggerConds.Add(Activator.CreateInstance(v) as ITriggerCond);
                }
                foreach (var v in TriggerMgr.Instance.AllActionType)
                {
                    trigger.TriggerActions.Add(Activator.CreateInstance(v) as ITriggerAction);
                }

                TriggerLine.Triggers.Add(trigger);
            }
            {
                var trigger = new Trigger();
                foreach (var v in TriggerMgr.Instance.AllCondType)
                {
                    trigger.TriggerConds.Add(Activator.CreateInstance(v) as ITriggerCond);
                }
                foreach (var v in TriggerMgr.Instance.AllActionType)
                {
                    trigger.TriggerActions.Add(Activator.CreateInstance(v) as ITriggerAction);
                }

                TriggerLine.Triggers.Add(trigger);
            }

            var filePath = dirPath + "/TriggerLineTemplate.json";
            File.WriteAllText(filePath,JsonConvert.SerializeObject(TriggerLine));

        }
    }
}