using System;
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
    [Rotation(ClassJobType.Bard)]
    public class BardRotation : IRotation
    {

        private AIRoot AiRoot = AIRoot.Instance;

        private long randomTime;
        private long _lastTime;

        public void Init()
        {
            BardSpellHelper.Init();
        }

        public Task<bool> Rest()
        {
            var needRest = Core.Me.CurrentHealthPercent < SettingMgr.GetSetting<BardSettings>().RestHealthPercent;
            return Task.FromResult(needRest);
        }

        // 战斗之前处理buff的?
        public async Task<bool> PreCombatBuff()
        {
            if (Core.Me.InCombat)
            {
                return false;
            }


            AIRoot.Instance.Clear();

            if (Core.Me.HasTarget && Core.Me.CurrentTarget.CanAttack)
                return false;

            if (PartyManager.IsInParty)
            {
                if (TargetMgr.Instance.EnemysIn25.Count > 0)
                    return false;
            }

            if (!MovementManager.IsMoving)
                return false;

            if (!SettingMgr.GetSetting<BardSettings>().UsePeloton)
            {
                GUIHelper.ShowInfo("非战斗状态,速行未开启");
                return false;
            }

            GUIHelper.ShowInfo("非战斗状态,速行逻辑判断中");

            if (Core.Me.HasTarget && Core.Me.CurrentTarget.CanAttack)
                return false;

            if (Core.Me.ContainAura(AurasDefine.Peloton, 100))
                return false;

            if (_lastTime == 0)
                _lastTime = TimeHelper.Now();
            else
            {
                var now = TimeHelper.Now();
                randomTime += now - _lastTime;
                _lastTime = TimeHelper.Now();
            }

            // 防止每次都立即开疾行,搞的很假
            if (RandomHelper.RandomInt(2000, 5000) > randomTime)
                return false;

            if (await SpellHelper.CastAbility(Spells.Peloton, Core.Me))
            {
                GUIHelper.ShowInfo("使用速行!");
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
            CountDownHandler.Instance.Update();
            TargetMgr.Instance.Update();
            return AiRoot.Update();
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
    }
}