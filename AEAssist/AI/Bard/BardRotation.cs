using System.Threading.Tasks;
using AEAssist.AI;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Enums;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist
{
    [Rotation(ClassJobType.Bard)]
    public class BardRotation : IRotation
    {
        private long _lastTime;
        private readonly AIRoot AiRoot = AIRoot.Instance;

        private long randomTime;

        public void Init()
        {
            BardSpellHelper.Init();
            CountDownHandler.Instance.AddListener(1500, () =>
                PotionHelper.UsePotion(SettingMgr.GetSetting<GeneralSettings>().DexPotionId));
            DataBinding.Instance.EarlyDecisionMode = SettingMgr.GetSetting<BardSettings>().EarlyDecisionMode;
            LogHelper.Info("EarlyDecisionMode: "+ DataBinding.Instance.EarlyDecisionMode);
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

            // 防止每次都立即开疾行,搞的很假
            if (RandomHelper.RandomInt(2000, 5000) > randomTime)
                return false;

            if (await SpellHelper.CastAbility(SpellsDefine.Peloton, Core.Me))
            {
                GUIHelper.ShowInfo(Language.Instance.Content_Bard_PreCombat3);
                randomTime = 0;
                return true;
            }

            return false;
        }

        public SpellData GetBaseGCDSpell()
        {
            return BardSpellHelper.GetBaseGCD();
        }
        
    }
}