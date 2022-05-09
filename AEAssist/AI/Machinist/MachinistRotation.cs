using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using AEAssist.Rotations.Core;
using ff14bot;
using ff14bot.Enums;
using ff14bot.Managers;
using Language = AEAssist.Language;

namespace AEAssist.AI.Machinist
{
    [Job(ClassJobType.Machinist)]
    public class MachinistRotation : IRotation
    {
        public void Init()
        {
            CountDownHandler.Instance.AddListener(1500,
                () => PotionHelper.UsePotion(SettingMgr.GetSetting<GeneralSettings>().DexPotionId));

            CountDownHandler.Instance.AddListener(4800,
                () => SpellsDefine.Reassemble.DoAbility());

            AEAssist.DataBinding.Instance.EarlyDecisionMode = SettingMgr.GetSetting<MCHSettings>().EarlyDecisionMode;
        }
        
        public async Task<bool> PreCombatBuff()
        {
            if (PartyManager.IsInParty)
                if (TargetMgr.Instance.EnemysIn25.Count > 0)
                    return false;

            if (!SettingMgr.GetSetting<BardSettings>().UsePeloton)
            {
                GUIHelper.ShowInfo(Language.Instance.Content_Bard_PreCombat1);
                return false;
            }

            if (Core.Me.HasTarget && Core.Me.CurrentTarget.CanAttack)
                return false;

            if (Core.Me.ContainAura(AurasDefine.Peloton, 100))
                return false;

            if (await SpellsDefine.Peloton.DoAbility())
            {
                GUIHelper.ShowInfo(Language.Instance.Content_Bard_PreCombat3);
                return true;
            }

            return false;
        }
        public Task<bool> NoTarget()
        {
            return Task.FromResult(false);
        }
        public SpellEntity GetBaseGCDSpell()
        {
            return MCHSpellHelper.GetSplitShot();
        }
    }
}