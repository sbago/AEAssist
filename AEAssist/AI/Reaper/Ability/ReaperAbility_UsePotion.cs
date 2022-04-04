using System.Threading.Tasks;
using AEAssist.AI.Reaper;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist.AI
{
    public class ReaperAbility_UsePotion : IAIHandler
    {
        public bool Check(SpellData lastSpell)
        {
            if (!SettingMgr.GetSetting<GeneralSettings>().UsePotion)
                return false;
            if (AIRoot.Instance.CloseBuff)
                return false;
            if (TTKHelper.IsTargetTTK(Core.Me.CurrentTarget as Character))
                return false;

            if (AIRoot.Instance.BattleData.maxAbilityTimes <
                SettingMgr.GetSetting<GeneralSettings>().MaxAbilityTimsInGCD)
                return false;

            if (!PotionHelper.CheckPotion(SettingMgr.GetSetting<ReaperSettings>().UsePotionId))
                return false;
            
            if (SpellsDefine.PlentifulHarvest.IsUnlock() 
            && !Core.Me.HasAura(AurasDefine.BloodsownCircle)
                &&Core.Me.HasAura(AurasDefine.ImmortalSacrifice))
            {
                return true;
            }

            //todo: 优化,如果没解锁圣餐, 就绑定附体状态用
            if (!SpellsDefine.PlentifulHarvest.IsUnlock() && ActionResourceManager.Reaper.ShroudGauge>50)
                return true;
            
            return false;
        }

        public async Task<SpellData> Run()
        {
            var ret = PotionHelper.UsePotion(SettingMgr.GetSetting<ReaperSettings>().UsePotionId);
            if (ret)
            {
                AIRoot.Instance.MuteAbilityTime();
            }
            await Task.CompletedTask;
            return null;
        }
    }
}