using System.Collections.Generic;
using System.Threading.Tasks;
using AEAssist.Helper;
using ff14bot.Enums;
using AEAssist.AI.GunBreaker.GCD;
using AEAssist.AI.GunBreaker.Ability;

namespace AEAssist.AI.Gunbreaker
{
    [Job(ClassJobType.Gunbreaker)]
    public class GunBreaker_AIPriority : IAIPriorityQueue
    {
        public List<IAIHandler> GCDQueue { get; } = new List<IAIHandler>()
        {
            //new GunBreakerGCD_DoubleDown(),
            new GunBreakerGCD_SecondaryCombo(),
            new GunBreakerGCD_SonicBreak(),
            new GunBreakerGCD_DoubleDown(),
            new GunBreakerGCD_BurstStrike(),
            new GunBreakerGCD_BaseGCDCombo()
        };

        public List<IAIHandler> AbilityQueue { get; } = new List<IAIHandler>()
        {
            new GunBreakerAbility_NoMercy(),
            new GunBreakerAbility_BowShock(),
            new GunBreakerAbility_Continuation(),
            //new GunBreakerAbility_NoMercy(),
            //new GunBreakerAbility_RoughDivide(),
            new GunBreakerAbility_Bloodfest(),
            new GunBreakerAbility_BlastingZone(),
            //new GunBreakerAbility_BowShock(),
            new GunBreakerAbility_RoughDivide()
        };

        public async Task<bool> UsePotion()
        {
            return await PotionHelper.ForceUsePotion(SettingMgr.GetSetting<GeneralSettings>().StrPotionId);
        }
    }
}