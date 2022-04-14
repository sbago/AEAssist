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
        }

        public Task<bool> Rest()
        {
            return Task.FromResult(false);
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

        public Task<bool> Pull()
        {
            return Task.FromResult(false);
        }

        public Task<bool> Heal()
        {
            return Task.FromResult(false);
        }

        public Task<bool> CombatBuff()
        {
            return Task.FromResult(false);
        }

        public Task<bool> Combat()
        {
            return Task.FromResult(false);
        }

        public Task<bool> PullBuff()
        {
            return Task.FromResult(false);
        }

        public SpellData GetBaseGCDSpell()
        {
            return BardSpellHelper.GetHeavyShot();
        }
        
    }
}