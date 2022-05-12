using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using AEAssist.Rotations.Core;
using ff14bot.Enums;

namespace AEAssist.AI.Sage
{
    [Job(ClassJobType.Sage)]
    public class SageRotation : IRotation
    {
        // private readonly AIRoot AiRoot = AIRoot.Instance;
        // private long _lastTime;
        // private long randomTime;
        //
        
        public void Init()
        {
            CountDownHandler.Instance.AddListener(2000, () => SageSpellHelper.GetEukrasianDosis().DoGCD());
            AEAssist.DataBinding.Instance.EarlyDecisionMode = SettingMgr.GetSetting<SageSettings>().EarlyDecisionMode;
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
            return SageSpellHelper.GetBaseGCD();
        }
    }
}