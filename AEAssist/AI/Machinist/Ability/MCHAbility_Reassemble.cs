using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist.AI.MCH
{
    public class MCHAbility_Reassemble : IAIHandler
    {
        public int Check(SpellData lastSpell)
        {
            if (!SpellsDefine.Reassemble.IsReady())
                return -1;
            if (ActionResourceManager.Machinist.OverheatRemaining.TotalMilliseconds > 0)
                return -10;

            var time = AIRoot.Instance.GetGCDDuration() * 0.66f -
                       (2 - AIRoot.GetBattleData<BattleData>().maxAbilityTimes)
                       * SettingMgr.GetSetting<GeneralSettings>().ActionQueueMs;

            if (!MCHSpellHelper.CheckReassmableGCD((int) time))
                return -2;

            return 0;

        }

        public async Task<SpellData> Run()
        {
            if (await SpellHelper.CastAbility(SpellsDefine.Reassemble, Core.Me))
            {
                return SpellsDefine.Reassemble;
            }

            return null;
        }
    }
}