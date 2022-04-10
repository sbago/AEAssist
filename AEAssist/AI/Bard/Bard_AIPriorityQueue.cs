using System.Collections.Generic;
using System.Threading.Tasks;
using AEAssist.AI;
using AEAssist.Helper;
using ff14bot.Enums;
using ff14bot.Objects;

namespace AEAssist.Define
{
    public class Bard_AIPriorityQueue : IAIPriorityQueue
    {
        public List<IAIHandler> GCDQueue { get; } = new List<IAIHandler>()
        {
            new BardGCD_BlastArrow(),
            new BardGCD_Barrage_RefulgentArrow(),
            new BardGCD_Dot(),
            new BardGCD_ApexArrow(),
            new BardGCD_QuickNock(),
            new BardGCD_HeavyShot()
        };

        public List<IAIHandler> AbilityQueue { get; } = new List<IAIHandler>()
        {
            new BardAbility_UsePotion(),
            new BardAbility_PitchPerfect(),
            new BardAbility_Buffs(),
            new BardAbility_Songs(),
            new BardAbility_RagingStrikes(),
            new BardAbility_EmpyrealArrow(),
            new BardAbility_MaxChargeBloodletter(),
            new BardAbility_Barrage(),
            new BardAbility_Sidewinder(),
            new BardAbility_Bloodletter()
        };

        public async Task<bool> UsePotion()
        {
            return await PotionHelper.ForceUsePotion(SettingMgr.GetSetting<BardSettings>().UsePotionId);
        }
    }
}