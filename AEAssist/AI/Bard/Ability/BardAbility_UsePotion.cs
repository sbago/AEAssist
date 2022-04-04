using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Objects;

namespace AEAssist.AI
{
    public class BardAbility_UsePotion : IAIHandler
    {
        public bool Check(SpellData lastSpell)
        {
            if (!SettingMgr.GetSetting<GeneralSettings>().UsePotion)
                return false;
            if (AIRoot.Instance.CloseBuff)
                return false;
            if (AIRoot.Instance.BattleData.maxAbilityTimes <
                SettingMgr.GetSetting<GeneralSettings>().MaxAbilityTimsInGCD)
                return false;
            if (TTKHelper.IsTargetTTK(Core.Me.CurrentTarget as Character))
                return false;
            if (!PotionHelper.CheckPotion(SettingMgr.GetSetting<BardSettings>().UsePotionId))
                return false;

            return true;
        }

        public async Task<SpellData> Run()
        {
            var ret = PotionHelper.UsePotion(SettingMgr.GetSetting<BardSettings>().UsePotionId);
            if (ret)
            {
                AIRoot.Instance.MuteAbilityTime();
            }

            await Task.CompletedTask;
            return null;
        }
    }
}