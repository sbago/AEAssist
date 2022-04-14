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
    [Rotation(ClassJobType.Reaper)]
    public class ReaperRotation : IRotation
    {
        private long _lastTime;
        private readonly AIRoot AiRoot = AIRoot.Instance;

        private long randomTime;

        public void Init()
        {
            CountDownHandler.Instance.AddListener(1500, () =>
            {
                if (Core.Me.HasTarget && Core.Me.CurrentTarget.CanAttack)
                    return SpellHelper.CastGCD(SpellsDefine.Harpe, Core.Me.CurrentTarget);
                return Task.FromResult(false);
            });
            DataBinding.Instance.EarlyDecisionMode = SettingMgr.GetSetting<ReaperSettings>().EarlyDecisionMode;
            LogHelper.Info("EarlyDecisionMode: "+ DataBinding.Instance.EarlyDecisionMode);
        }

        public Task<bool> Rest()
        {
            // var needRest = Core.Me.CurrentHealthPercent < SettingMgr.GetSetting<BardSettings>().RestHealthPercent;
            return Task.FromResult(false);
        }

        // 战斗之前处理buff的?
        public async Task<bool> PreCombatBuff()
        {
            if (Core.Me.InCombat) return false;


            AIRoot.Instance.Clear();

            if (Core.Me.HasTarget && Core.Me.CurrentTarget.CanAttack)
                return false;

            if (MovementManager.IsMoving)
                return false;

            GUIHelper.ShowInfo(Language.Instance.Content_Reaper_PreCombat1);


            if (Core.Me.HasAura(AurasDefine.Soulsow))
                return true;

            if (await SpellHelper.CastGCD(SpellsDefine.Soulsow, Core.Me))
            {
                GUIHelper.ShowInfo(Language.Instance.Content_Reaper_PreCombat2);
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
            return SpellsDefine.Slice;
        }
    }
}