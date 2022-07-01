﻿using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using AEAssist.Rotations.Core;
using ff14bot;
using ff14bot.Enums;

namespace AEAssist.AI.Samurai
{
    [Job(ClassJobType.Samurai)]
    public class SamuraiRotation : IRotation
    {
        private readonly AIRoot AiRoot = AIRoot.Instance;
        private long _lastTime;

        private long randomTime;

        public void Init()
        {
            CountDownHandler.Instance.AddListener(9000, () => SpellsDefine.MeikyoShisui.DoAbility());
            DataBinding.Instance.EarlyDecisionMode = SettingMgr.GetSetting<SamuraiSettings>().EarlyDecisionMode;
            LogHelper.Info("EarlyDecisionMode: " + DataBinding.Instance.EarlyDecisionMode);
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
            return SpellsDefine.Hakaze.GetSpellEntity();
        }
    }
}