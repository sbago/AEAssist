using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using AEAssist.Rotations.Core;
using ff14bot;
using ff14bot.Enums;
using ff14bot.Managers;
using Language = AEAssist.Language;

namespace AEAssist.AI.Bard
{
    [Job(ClassJobType.Bard)]
    public class BardRotation : IRotation
    {
        private readonly AIRoot AiRoot = AIRoot.Instance;
        private long _lastTime;

        private long randomTime;

        public void Init()
        {
            BardSpellHelper.Init();
            CountDownHandler.Instance.AddListener(1500, () =>
                PotionHelper.UsePotion(SettingMgr.GetSetting<GeneralSettings>().DexPotionId));
            AEAssist.DataBinding.Instance.EarlyDecisionMode = SettingMgr.GetSetting<BardSettings>().EarlyDecisionMode;
            LogHelper.Info("EarlyDecisionMode: " + AEAssist.DataBinding.Instance.EarlyDecisionMode);
        }

        // 战斗之前处理buff的?
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

            if (_lastTime == 0)
            {
                _lastTime = TimeHelper.Now();
            }
            else
            {
                var now = TimeHelper.Now();
                randomTime += now - _lastTime;
                _lastTime = TimeHelper.Now();
            }
            
            if (RandomHelper.RandomInt(2000, 5000) > randomTime)
                return false;

            if (await SpellsDefine.Peloton.DoAbility())
            {
                GUIHelper.ShowInfo(Language.Instance.Content_Bard_PreCombat3);
                randomTime = 0;
                return true;
            }

            return false;
        }

        public SpellEntity GetBaseGCDSpell()
        {
            return BardSpellHelper.GetBaseGCD();
        }
    }
}