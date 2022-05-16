using System.Collections.Generic;
using System.Threading.Tasks;
using AEAssist.AI.Samurai.Ability;
using AEAssist.AI.Samurai.GCD;
using AEAssist.Helper;
using ff14bot.Enums;

namespace AEAssist.AI.Samurai
{
    [Job(ClassJobType.Samurai)]
    public class Samurai_AIPriorityQueue : IAIPriorityQueue
    {
        public List<IAIHandler> GCDQueue { get; } = new List<IAIHandler>
        {
            new SamuraiGCD_Kaeshi(),
            new SamuraiGCD_OgiNamikiri(),
            new SamuraiGCD_Iaijutsu(),
            new SamuraiGCD_BaseGCDCombo()
            //new test()
        };

        public List<IAIHandler> AbilityQueue { get; } = new List<IAIHandler>
        {
            new SamuraiAbility_HissatsuKaiten(),
            new SamuraiAbility_Ikishoten(),
            new SamuraiAbility_MeikyoShisui(),
            new SamuraiAbility_HissatsuShinten(),
            new SamuraiAbility_Shoha(),
            new SamuraiAbility_HissatsuSenei()
        };

        public Task<bool> UsePotion()
        {
            return PotionHelper.ForceUsePotion(SettingMgr.GetSetting<GeneralSettings>().StrPotionId);
        }
    }
}