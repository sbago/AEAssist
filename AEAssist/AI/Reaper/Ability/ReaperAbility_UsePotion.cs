using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist.AI
{
    public class ReaperAbility_UsePotion : IAIHandler
    {
        public int Check(SpellData lastSpell)
        {
            if (!SettingMgr.GetSetting<GeneralSettings>().UsePotion)
                return -1;
            if (AIRoot.Instance.BurstOff)
                return -2;
            if (TTKHelper.IsTargetTTK(Core.Me.CurrentTarget as Character))
                return -3;

            if (AIRoot.Instance.BattleData.maxAbilityTimes <
                SettingMgr.GetSetting<GeneralSettings>().MaxAbilityTimsInGCD)
                return -4;

            if (!PotionHelper.CheckPotion(SettingMgr.GetSetting<GeneralSettings>().StrPotionId))
                return -5;

            if (SpellsDefine.PlentifulHarvest.IsReady()
                && Core.Me.ContainsMyInEndAura(AurasDefine.BloodsownCircle, 3000))
                return 1;


            //todo: 优化,如果没冷却好圣餐或者没解锁, 就绑定附体状态用
            if (!SpellsDefine.PlentifulHarvest.IsReady() && ActionResourceManager.Reaper.ShroudGauge > 50)
                return 2;

            return -6;
        }

        public async Task<SpellData> Run()
        {
            var ret = await PotionHelper.UsePotion(SettingMgr.GetSetting<GeneralSettings>().StrPotionId);
            if (ret) AIRoot.Instance.MuteAbilityTime();

            await Task.CompletedTask;
            return null;
        }
    }
}