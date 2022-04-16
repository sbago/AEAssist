using System.Threading.Tasks;
using AEAssist.AI;
using AEAssist.Define;
using AEAssist.Helper;
using Buddy.Coroutines;
using ff14bot;
using ff14bot.Enums;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist
{
    [Rotation(ClassJobType.Machinist)]
    public class MachinistRotation : IRotation
    {
        public void Init()
        {
            CountDownHandler.Instance.AddListener(1500, 
                () => PotionHelper.UsePotion(SettingMgr.GetSetting<GeneralSettings>().DexPotionId));
            
            CountDownHandler.Instance.AddListener(4800, 
                () => SpellHelper.CastAbility(SpellsDefine.Reassemble, Core.Me), false);
        }
        

        // 战斗之前处理buff的?
        public async Task<bool> PreCombatBuff()
        {
            if (Core.Me.InCombat) return false;


            AIRoot.Instance.Clear();

            if (Core.Me.HasTarget && Core.Me.CurrentTarget.CanAttack)
                return false;

            if (PartyManager.IsInParty)
                if (TargetMgr.Instance.EnemysIn25.Count > 0)
                    return false;

            if (!MovementManager.IsMoving)
                return false;
            
            await CountDownHandler.Instance.Update();

            if (CountDownHandler.Instance.Start)
                return false;

            if (!SettingMgr.GetSetting<BardSettings>().UsePeloton)
            {
                GUIHelper.ShowInfo(Language.Instance.Content_Bard_PreCombat1);
                return false;
            }

            GUIHelper.ShowInfo(Language.Instance.Content_Bard_PreCombat2);

            if (Core.Me.HasTarget && Core.Me.CurrentTarget.CanAttack)
                return false;

            if (Core.Me.ContainAura(AurasDefine.Peloton, 100))
                return false;
            
            if (await SpellHelper.CastAbility(SpellsDefine.Peloton, Core.Me))
            {
                GUIHelper.ShowInfo(Language.Instance.Content_Bard_PreCombat3);
                return true;
            }

            return false;
        }
        
        public SpellData GetBaseGCDSpell()
        {
            return MCHSpellHelper.GetSplitShot();
        }
    }
}