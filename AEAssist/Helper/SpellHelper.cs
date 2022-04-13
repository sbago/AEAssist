using System;
using System.Threading.Tasks;
using AEAssist.Define;
using Buddy.Coroutines;
using ff14bot;
using ff14bot.Enums;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist.Helper
{
    public static class SpellHelper
    {
        public static async Task<bool> CastGCD(SpellData spell, GameObject target)
        {
            if (spell.SpellType == SpellType.Ability)
            {
                LogHelper.Error($"{spell.Name} is not a GCD");
                return false;
            }

            if (!ActionManager.HasSpell(spell.Id))
                return false;

            if (!GameSettingsManager.FaceTargetOnAction)
                GameSettingsManager.FaceTargetOnAction = true;

            if (spell.GroundTarget)
            {
                if (!ActionManager.CanCastLocation(spell.Id, target.Location))
                    return false;
                if (!ActionManager.DoActionLocation(spell.Id, target.Location))
                    return false;
            }
            else
            {
                if (DataBinding.Instance.EarlyDecisionMode)
                {
                    if (!ActionManager.CanCastOrQueue(spell, target))
                        return false;
                }
                else
                {
                    if (!ActionManager.CanCast(spell, target))
                        return false;
                }

                if (!ActionManager.DoAction(spell, target))
                    return false;
            }

            // 等待cast 结束
            if (spell.AdjustedCastTime != TimeSpan.Zero)
                if (!await Coroutine.Wait(spell.BaseCastTime + TimeSpan.FromMilliseconds(500), () => Core.Me.IsCasting))
                    return false;

            return true;
        }


        public static async Task<bool> CastAbility(SpellData spell, GameObject target, int waitTime = 0)
        {
            if (waitTime == 0)
                waitTime = SettingMgr.GetSetting<GeneralSettings>().AnimationLockMs;


            if (spell.Id != SpellsDefine.Sprint.Id && spell.SpellType != SpellType.Ability)
            {
                LogHelper.Error($"{spell.Name} is not a Ability");
                return false;
            }

            //LogHelper.Debug("准备使用能力 : " + spell.Name);

            if (!ActionManager.HasSpell(spell.Id))
                return false;

            if (!GameSettingsManager.FaceTargetOnAction)
                GameSettingsManager.FaceTargetOnAction = true;


            if (!ActionManager.CanCast(spell.Id, target))
                return false;
            if (!ActionManager.DoAction(spell, target))
                return false;

            var needTime = (int) spell.AdjustedCastTime.TotalMilliseconds + waitTime;

            if (needTime <= 10)
                return true;

            await Coroutine.Wait(needTime, () => false);
            return true;
        }

        public static bool IsUnlock(this SpellData spellData)
        {
            if (Core.Me.ClassLevel < spellData.LevelAcquired
                || !ActionManager.HasSpell(spellData.Id))
                return false;
            return true;
        }

        public static bool IsReady(this SpellData spellData)
        {
            // LogHelper.Debug($"检测技能 {spellData.Name} {spellData.LocalizedName} AdCoolDown {spellData.AdjustedCooldown.TotalMilliseconds}");
            if (!spellData.IsUnlock())
                return false;

            if (spellData.SpellType == SpellType.Ability || SpellsDefine.OffGCD_NoCharge.Contains(spellData.Id))
            {
                if (spellData.Cooldown.TotalMilliseconds > 0)
                    return false;
            }

            return true;
        }

        public static bool IsChargeReady(this SpellData spellData)
        {
            // LogHelper.Debug($"检测技能 {spellData.Name} {spellData.LocalizedName} AdCoolDown {spellData.AdjustedCooldown.TotalMilliseconds}");
            if (!spellData.IsUnlock()
                || spellData.Charges < 1)
                return false;
            return true;
        }
        
        public static bool IsMaxChargeReady(this SpellData spellData)
        {
            // LogHelper.Debug($"检测技能 {spellData.Name} {spellData.LocalizedName} AdCoolDown {spellData.AdjustedCooldown.TotalMilliseconds}");
            if (!spellData.IsUnlock()
                || spellData.Charges < spellData.MaxCharges - 0.2f)
                return false;
            return true;
        }
    }
}