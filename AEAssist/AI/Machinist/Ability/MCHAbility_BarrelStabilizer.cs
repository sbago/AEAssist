using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist.AI.MCH
{
    public class MCHAbility_BarrelStabilizer : IAIHandler
    {
        public int Check(SpellData lastSpell)
        {
            if (!SpellsDefine.BarrelStabilizer.IsReady())
                return -1;
            if (ActionResourceManager.Machinist.Heat > 50)
                return -2;
            if (AIRoot.Instance.CloseBurst)
                return -3;
            if (TTKHelper.IsTargetTTK(Core.Me.CurrentTarget as Character))
                return -4;

            return 0;
        }

        public async Task<SpellData> Run()
        {
            if (await SpellHelper.CastAbility(SpellsDefine.BarrelStabilizer, Core.Me))
            {
                return SpellsDefine.BarrelStabilizer;
            }

            return null;
        }
    }
}