using System.Threading.Tasks;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Helpers;
using ff14bot.Objects;

namespace AEAssist.AI
{
    public class AIRoot
    {
        public static readonly AIRoot Instance = new AIRoot();
        
        private long _lastCastTime;
        private SpellData _lastGCDSpell;
        private SpellData _lastAbilitySpell;
        private int _maxAbilityTimes ;

        public AIRoot()
        {
            _lastCastTime = TimeHelper.Now();
            _maxAbilityTimes = GeneralSettings.Instance.MaxAbilityTimsInGCD;
        }


        public async Task<bool> Update()
        {
            // 逻辑清单: 
            // 1. 检测当前是否可以使用GCD技能

            if (ff14bot.Core.Me.IsCasting)
                return false;

            if (ff14bot.Core.Target == null || !ff14bot.Core.Target.CanAttack)
                return false;

            var timeNow = TimeHelper.Now();

            bool canUseGCD = true;
            bool canUseAbility = false;

            if (_lastGCDSpell != null)
            {
                var delta = timeNow - _lastCastTime;
                var coolDown = _lastGCDSpell.AdjustedCooldown.TotalMilliseconds;
                var coolDownForQueue = coolDown - GeneralSettings.Instance.ActionQueueMs;
                var halfCoolDown = coolDown / GeneralSettings.Instance.MaxAbilityTimsInGCD;
                if (delta < coolDownForQueue)
                {
                    canUseGCD = false;
                }

                var needDura = ConstValue.AnimationLockMs + GeneralSettings.Instance.UserLatencyOffset;
                if (coolDown - delta > needDura)
                {
                    // 可以使用前半段GCD的能力技
                    if (_maxAbilityTimes == GeneralSettings.Instance.MaxAbilityTimsInGCD && delta < halfCoolDown)
                    {
                        canUseAbility = true;
                    }
                    else if (delta >= halfCoolDown)
                    {
                        // 可以使用后半段GCD的能力技
                        canUseAbility = true;
                    }
                }

            }

            if (canUseGCD)
            {
                //todo: check gcd
                var ret = await AIMgrs.Instance.HandleGCD(Core.Me.CurrentJob,_lastGCDSpell);
                if (ret != null)
                {
                    _lastGCDSpell = ret;
                    _lastCastTime = timeNow;
                    _maxAbilityTimes = GeneralSettings.Instance.MaxAbilityTimsInGCD;
                    _lastAbilitySpell = null;
                }
            }
            else if (canUseAbility)
            {
                //todo : check ability
                var ret = await AIMgrs.Instance.HandleAbility(Core.Me.CurrentJob,_lastAbilitySpell);
                if (ret != null)
                {
                    _maxAbilityTimes--;
                    LogHelper.Info($"剩余使用能力技能次数: {_maxAbilityTimes}");
                }
            }

            return false;
        }

        // 当前是否是GCD后半段
        public bool Is2ndAbilityTime()
        {
            if (_lastGCDSpell == null)
                return false;
            if (_maxAbilityTimes == 1)
                return true;
            if (GeneralSettings.Instance.MaxAbilityTimsInGCD != 2)
                return true;
            var timeNow = TimeHelper.Now();
            var delta = timeNow - _lastCastTime;
            var coolDown = _lastGCDSpell.AdjustedCooldown.TotalMilliseconds;
            if (delta > coolDown / GeneralSettings.Instance.MaxAbilityTimsInGCD)
                return true;
            return false;
        }

        public double GetGCDDuration()
        {
            if (_lastGCDSpell == null)
                return 2500;
            return _lastGCDSpell.AdjustedCooldown.TotalMilliseconds;
        }
    }
}