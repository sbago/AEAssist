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
    [Rotation(ClassJobType.Samurai)]
    public class SamuraiRotation : IRotation
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
            DataBinding.Instance.EarlyDecisionMode = SettingMgr.GetSetting<SamuraiSettings>().EarlyDecisionMode; 
            LogHelper.Info("EarlyDecisionMode: " + DataBinding.Instance.EarlyDecisionMode);
        }

        // 战斗之前处理buff的?
        public async Task<bool> PreCombatBuff()
        {
            if (Core.Me.InCombat) return false;


            AIRoot.Instance.Clear();

            if (Core.Me.HasTarget && Core.Me.CurrentTarget.CanAttack)
                return false;

            if (!MovementManager.IsMoving)
                return false;

            if (await SpellHelper.CastGCD(SpellsDefine.Soulsow, Core.Me))
                return true;

            return false;
        }

        public SpellData GetBaseGCDSpell()
        {
            return SpellsDefine.Hakaze;
        }
    }


}
