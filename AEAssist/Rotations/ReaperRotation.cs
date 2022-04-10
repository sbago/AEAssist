using System;
using System.Threading.Tasks;
using AEAssist.AI;
using AEAssist.AI.Reaper;
using AEAssist;
using AEAssist.Define;
using AEAssist.Helper;
using Buddy.Coroutines;
using ff14bot;
using ff14bot.Enums;
using ff14bot.Helpers;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist
{
    [Rotation(ClassJobType.Reaper)]
    public class ReaperRotation : IRotation
    {
        private AIRoot AiRoot = AIRoot.Instance;

        private long randomTime;
        private long _lastTime;

        public void Init()
        {
        }

        public Task<bool> Rest()
        {
            // var needRest = Core.Me.CurrentHealthPercent < SettingMgr.GetSetting<BardSettings>().RestHealthPercent;
            return Task.FromResult(false);
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

            if (MovementManager.IsMoving)
                return false;

            GUIHelper.ShowInfo("非战斗状态");


            if (Core.Me.HasAura(AurasDefine.Soulsow))
                return true;

            if (await SpellHelper.CastGCD(SpellsDefine.Soulsow, Core.Me))
            {
                GUIHelper.ShowInfo("使用收获月!");
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

        public SpellData GetBaseGCDSpell()
        {
            return SpellsDefine.Slice;
        }

        public void HandleInCountDown1500()
        {
            if (Core.Me.HasTarget && Core.Me.CurrentTarget.CanAttack)
                _ = SpellHelper.CastGCD(SpellsDefine.Harpe, Core.Me.CurrentTarget);
        }
    }
}