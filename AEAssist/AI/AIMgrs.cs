using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AEAssist.AI;
using AEAssist.Define;
using ff14bot.Enums;
using ff14bot.Objects;

namespace AEAssist.AI
{
    public class AIMgrs
    {
        public static readonly AIMgrs Instance = new AIMgrs();

        public AIMgrs()
        {
            this.JobPriorityQueue.Add(ClassJobType.Reaper,new Reaper_AIPriorityQueue());
            this.JobPriorityQueue.Add(ClassJobType.Bard,new Bard_AIPriorityQueue());
        }

        public Dictionary<ClassJobType, IAIPriorityQueue> JobPriorityQueue =
            new Dictionary<ClassJobType, IAIPriorityQueue>();

        public async Task<SpellData> HandleGCD(ClassJobType classJobType,SpellData lastGCD)
        {
            if (!JobPriorityQueue.TryGetValue(classJobType, out var queue))
            {
                return null;
            }
            
            foreach (var v in queue.GCDQueue)
            {
                if (v.Check(lastGCD)>=0)
                {
                    return await v.Run();
                }
            }
            
            return null;
        }
        
        public async Task<SpellData> HandleAbility(ClassJobType classJobType,SpellData lastAbility)
        {
            if (!JobPriorityQueue.TryGetValue(classJobType, out var queue))
            {
                return null;
            }
            
            foreach (var v in queue.AbilityQueue)
            {
                var ret = v.Check(lastAbility);
                if (ret>=0)
                {
                    return await v.Run();
                }
                else
                {
                    LogHelper.Debug($"Check:{v.GetType().Name } ret: {ret}");
                }
            }

            return null;
        }
    }
}