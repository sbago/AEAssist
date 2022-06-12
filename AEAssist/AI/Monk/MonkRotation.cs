using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using AEAssist.Rotations.Core;
using ff14bot.Enums;

namespace AEAssist.AI.Monk
{
    [Job(ClassJobType.Monk)]
    public class MonkRotation : IRotation
    {
        public void Init()
        {
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
            return SpellsDefine.SpinningEdge.GetSpellEntity();
        }
    }
}