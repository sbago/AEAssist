using System.Threading.Tasks;
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
            CountDownHandler.Instance.AddListener(10000, () => SpellsDefine.MeikyoShisui.DoAbility());
            CountDownHandler.Instance.AddListener(1000, () => SpellsDefine.TrueNorth.DoAbility());
            AEAssist.DataBinding.Instance.EarlyDecisionMode = SettingMgr.GetSetting<SamuraiSettings>().EarlyDecisionMode;
            LogHelper.Info("EarlyDecisionMode: " + AEAssist.DataBinding.Instance.EarlyDecisionMode);
        }
        
        public Task<bool> PreCombatBuff()
        {
            return Task.FromResult(false);
        }

        public SpellEntity GetBaseGCDSpell()
        {
            return SpellsDefine.Hakaze.GetSpellEntity();
        }
    }
}