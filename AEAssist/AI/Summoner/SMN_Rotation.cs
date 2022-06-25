using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using AEAssist.Rotations.Core;
using ff14bot.Enums;
using ff14bot;
using ff14bot.Managers;
using ff14bot.Objects;
using AEAssist.AI.Summoner.GCD;
using System;
using Buddy.Coroutines;

namespace AEAssist.AI.Summoner
{
    [Job(ClassJobType.Summoner)]
    public class SMN_Rotation : IRotation
    {
        public void Init()
        {
            //CountDownHandler.Instance.AddListener(1500,
            //    () => PotionHelper.UsePotion(SettingMgr.GetSetting<GeneralSettings>().MindPotionId));
            

            CountDownHandler.Instance.AddListener(1200,
                () => SpellsDefine.Ruin.DoGCD());

            AEAssist.DataBinding.Instance.EarlyDecisionMode = SettingMgr.GetSetting<SMNSettings>().EarlyDecisionMode;
        }
        public async Task<bool> PreCombatBuff()
        {
            var summonCarbuncle = new SMNGCD_SummonCarbuncle();
            if (summonCarbuncle.Check(null) >= 0)
            {
                await summonCarbuncle.DelayedRun();
                return true;
            }
                

            return false;
            
        }

        public async Task<bool> NoTarget()
        {
            
            return false;
        }

        public SpellEntity GetBaseGCDSpell()
        {
            return SMNGCD_Base.GetSpell().GetSpellEntity();
        }
    }
}