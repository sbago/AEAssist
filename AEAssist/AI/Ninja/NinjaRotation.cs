using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using AEAssist.Rotations.Core;
using ff14bot.Enums;

namespace AEAssist.AI.Ninja
{
    [Job(ClassJobType.Ninja)]
    public class NinjaRotation : IRotation
    {
        public void Init()
        {
            AEAssist.DataBinding.Instance.EarlyDecisionMode = SettingMgr.GetSetting<NinjaSetting>().EarlyDecisionMode;
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