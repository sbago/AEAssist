using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist.AI
{
    public class MCHAbility_WildFire : IAIHandler
    {
        public int Check(SpellData lastSpell)
        {
            if (!SpellsDefine.Wildfire.IsReady())
                return -1;
            if (AIRoot.Instance.BurstOff)
                return -2;
            if (ActionResourceManager.Machinist.Heat < 50)
                return -3;
            if (!AIRoot.Instance.Is2ndAbilityTime())
                return -4;
            
            if (SpellsDefine.BarrelStabilizer.IsReady())
                return -101;
            var lastGCDIndex = SpellHistoryHelper.GetLastGCDIndex(SpellsDefine.BarrelStabilizer.Id);
            if (AIRoot.Instance.BattleData.lastGCDIndex - lastGCDIndex < 3)
            {
                return -102;
            }
            
            return 0;
        }

        public async Task<SpellData> Run()
        {
            if (await SpellHelper.CastAbility(SpellsDefine.Wildfire, Core.Me.CurrentTarget))
            {
                return SpellsDefine.Wildfire;
            }

            return null;
        }
    }
}