using System;
using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using AEAssist.Rotations.Core;
using ff14bot.Enums;
using ff14bot.Objects;

namespace AEAssist.AI.Dancer
{
    [Job(ClassJobType.Dancer)] 
    public class DancerRotation : IRotation
    {
        public void Init()
        {
            // CountDownHandler.Instance.AddListener(21000, () => SpellsDefine.Sharpcast.DoAbility());
            // CountDownHandler.Instance.AddListener(3500, () => SpellsDefine.Fire3.DoAbility());
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