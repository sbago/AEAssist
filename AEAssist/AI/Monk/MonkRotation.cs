using System;
using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using AEAssist.Rotations.Core;
using ff14bot;
using ff14bot.Enums;
using ff14bot.Managers;

namespace AEAssist.AI.Monk
{
    [Job(ClassJobType.Monk)]
    public class MonkRotation : IRotation
    {
        public void Init()
        {
            Random rnd = new Random();
            int Timer = rnd.Next(5000, 10000);
            int ThunderClapTimer = rnd.Next(1800, 2100);
            CountDownHandler.Instance.AddListener(Timer, () => SpellsDefine.FormShift.DoGCD());
            CountDownHandler.Instance.AddListener(Timer-2000, () => SpellsDefine.Meditation.DoAbility());
            if (!ActionManager.CanCastOrQueue(SpellsDefine.Bootshine.GetSpellEntity().SpellData, Core.Me.CurrentTarget))
            {
                CountDownHandler.Instance.AddListener(ThunderClapTimer, () => SpellsDefine.Thunderclap.DoAbility());
            }
            AEAssist.DataBinding.Instance.EarlyDecisionMode = SettingMgr.GetSetting<MonkSettings>().EarlyDecisionMode;
            LogHelper.Info("EarlyDecisionMode: " + AEAssist.DataBinding.Instance.EarlyDecisionMode);
        }

        public async Task<bool> PreCombatBuff()
        {
            return false;
        }

        public async Task<bool> NoTarget()
        {
            return false;
        }

        public SpellEntity GetBaseGCDSpell()
        {
            return SpellsDefine.Bootshine.GetSpellEntity();
        }
    }
}