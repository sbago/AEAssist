using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot.Objects;

namespace AEAssist.AI
{
    public class BardAbility_UsePotion : IAIHandler
    {
        public bool Check(SpellData lastSpell)
        {
            if (!GeneralSettings.Instance.UsePotion)
                return false;
            if (AIRoot.Instance.CloseBuff)
                return false;
            if (!PotionHelper.CheckPotion(BardSettings.Instance.PotionId))
                return false;

            return true;
        }

        public async Task<SpellData> Run()
        {
            var ret = await PotionHelper.UsePotion(BardSettings.Instance.PotionId);
            if (ret)
            {
                AIRoot.Instance.MuteAbilityTime();
            }

            return null;
        }
    }
}