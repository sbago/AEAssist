using System;
using System.Threading.Tasks;
using AEAssist.AI;
using AEAssist.Define;
using AEAssist.Helper;
using Buddy.Coroutines;
using ff14bot;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist
{
    public class BardRotation : IRotation
    {

        private AIRoot AiRoot = AIRoot.Instance;

        private long randomTime;
        private long _lastTime;

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
            //LogHelper.Debug("Pull");
            return Combat();
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
            CountDownHandler.Instance.Update();
            // 更新当前的敌人列表
            TargetMgr.Instance.Update();
            return AiRoot.Update();
        }

        public Task<bool> PullBuff()
        {
            //LogHelper.Debug("PullBuff");
            return Task.FromResult(true);
        }
    }
}