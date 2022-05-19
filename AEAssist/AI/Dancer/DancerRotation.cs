using System;
using System.Threading.Tasks;
using AEAssist.AI.Sage;
using AEAssist.Define;
using AEAssist.Helper;
using AEAssist.Rotations.Core;
using ff14bot.Enums;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist.AI.Dancer
{
    [Job(ClassJobType.Dancer)] 
    public class DancerRotation : IRotation
    {
        public void Init()
        {
            Random rnd = new Random();
            int step1 = rnd.Next(9000, 13000);
            // int step2 = rnd.Next(4000, 8000);
            int PotionTimer = rnd.Next(1650, 1800);
            int step3 = rnd.Next(50, 200);
            CountDownHandler.Instance.AddListener(15000, () => SpellsDefine.StandardStep.DoGCD());
            CountDownHandler.Instance.AddListener(step1, () => DancerSpellHelper.PreCombatDanceSteps());
            CountDownHandler.Instance.AddListener(PotionTimer, () =>
                PotionHelper.UsePotion(SettingMgr.GetSetting<GeneralSettings>().DexPotionId));
            CountDownHandler.Instance.AddListener(step3, () => SpellsDefine.DoubleStandardFinish.DoGCD());
            AEAssist.DataBinding.Instance.EarlyDecisionMode = SettingMgr.GetSetting<DancerSetting>().EarlyDecisionMode;
            // LogHelper.Info("EarlyDecisionMode: " + AEAssist.DataBinding.Instance.EarlyDecisionMode);
        }

        public Task<bool> PreCombatBuff()
        {
            return Task.FromResult(false);
        }
        public Task<bool> NoTarget()
        {
            return Task.FromResult(false);
        }
        public SpellEntity GetBaseGCDSpell()
        {
            return SpellsDefine.Cascade.GetSpellEntity();
        }
    }
}