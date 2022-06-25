using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using AEAssist.Rotations.Core;
using ff14bot;
using ff14bot.Enums;

namespace AEAssist.AI.Gunbreaker
{
    [Job(ClassJobType.Gunbreaker)]
    public class GunBreakerRotation : IRotation
    {
        private readonly AIRoot AiRoot = AIRoot.Instance;
        private long _lastTime;

        private long randomTime;

        public void Init()
        {
                CountDownHandler.Instance.AddListener(300, () =>
                    SpellsDefine.LightningShot.DoGCD());

            AEAssist.DataBinding.Instance.EarlyDecisionMode = SettingMgr.GetSetting<GunBreakerSettings>().EarlyDecisionMode;
            LogHelper.Info("EarlyDecisionMode: " + AEAssist.DataBinding.Instance.EarlyDecisionMode);
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
            return SpellsDefine.KeenEdge.GetSpellEntity();
        }
    }
}

