using System.Collections.Generic;
using System.Threading.Tasks;
using AEAssist.AI.Ninja.GCD;
using AEAssist.Helper;
using ff14bot.Enums;

namespace AEAssist.AI.Ninja
{
    [Job(ClassJobType.Ninja)]
    public class Ninja_AIPriority : IAIPriorityQueue
    {
        public List<IAIHandler> GCDQueue { get; } = new List<IAIHandler>()
        {
            new Ninja_BaseCombo(),
        };

        public List<IAIHandler> AbilityQueue { get; } = new List<IAIHandler>()
        {

        };
        public async Task<bool> UsePotion()
        {
            return await PotionHelper.ForceUsePotion(SettingMgr.GetSetting<GeneralSettings>().DexPotionId);
        }
    }
}