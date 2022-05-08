using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using AEAssist.Rotations.Core;
using ff14bot.Enums;

namespace AEAssist.AI.BLM
{
    [Rotation(ClassJobType.BlackMage)]
    public class BLM_Rotation : IRotation
    {
        public void Init()
        {
            AEAssist.DataBinding.Instance.EarlyDecisionMode = SettingMgr.GetSetting<BLMSetting>().EarlyDecisionMode;
            LogHelper.Info("EarlyDecisionMode: " + AEAssist.DataBinding.Instance.EarlyDecisionMode);
        }

        public Task<bool> PreCombatBuff()
        {
            return Task.FromResult(false);
        }

        public SpellEntity GetBaseGCDSpell()
        {
            return SpellsDefine.Fire.GetSpellEntity();
        }
    }
}