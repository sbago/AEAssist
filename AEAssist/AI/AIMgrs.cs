using System.Collections.Generic;
using System.Threading.Tasks;
using AEAssist.Define;
using ff14bot.Enums;
using ff14bot.Objects;

namespace AEAssist.AI
{
    public class AIMgrs
    {
        public static readonly AIMgrs Instance = new AIMgrs();

        public Dictionary<ClassJobType, IAIPriorityQueue> JobPriorityQueue =
            new Dictionary<ClassJobType, IAIPriorityQueue>();

        public AIMgrs()
        {
            JobPriorityQueue.Add(ClassJobType.Reaper, new Reaper_AIPriorityQueue());
            JobPriorityQueue.Add(ClassJobType.Bard, new Bard_AIPriorityQueue());
            JobPriorityQueue.Add(ClassJobType.Machinist,new MCH_AIPriorityQueue());
        }

        public async Task<SpellData> HandleGCD(ClassJobType classJobType, SpellData lastGCD)
        {
            if (!JobPriorityQueue.TryGetValue(classJobType, out var queue)) return null;

            foreach (var v in queue.GCDQueue)
            {
                var ret = v.Check(lastGCD);
                if (ret >= 0)
                    return await v.Run();
                if (SettingMgr.GetSetting<GeneralSettings>().ShowAbilityDebugLog)
                    LogHelper.Debug(
                        $"{AIRoot.Instance.BattleData.BattleTime / 1000.0f:#0.000}  Check:{v.GetType().Name} ret: {ret}");
            }

            return null;
        }

        public async Task<SpellData> HandleAbility(ClassJobType classJobType, SpellData lastAbility)
        {
            if (!JobPriorityQueue.TryGetValue(classJobType, out var queue)) return null;

            foreach (var v in queue.AbilityQueue)
            {
                var ret = v.Check(lastAbility);
                if (ret >= 0)
                    return await v.Run();
                if (SettingMgr.GetSetting<GeneralSettings>().ShowAbilityDebugLog)
                    //   if(v.GetType() == typeof(BardAbility_Bloodletter))
                    LogHelper.Debug(
                        $"{AIRoot.Instance.BattleData.BattleTime / 1000.0f:#0.000}  Check:{v.GetType().Name} ret: {ret}");
            }

            return null;
        }

        public async Task<bool> UsePotion(ClassJobType classJobType)
        {
            if (!JobPriorityQueue.TryGetValue(classJobType, out var queue)) return false;

            return await queue.UsePotion();
        }
    }
}