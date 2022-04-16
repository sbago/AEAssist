using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist.AI.MCH
{
    public class MCHAbility_HyperCharge : IAIHandler
    {
        public int Check(SpellData lastSpell)
        {
            if (!SpellsDefine.Hypercharge.IsReady())
                return -1;
            if (AIRoot.Instance.BurstOff)
                return -2;
            if (ActionResourceManager.Machinist.Heat < 50)
                return -3;
            
            if (ActionResourceManager.Machinist.Heat >= 80)
                return 10;
            
            if (SpellsDefine.BarrelStabilizer.Cooldown.TotalMilliseconds<5000)
            {
                return 1;
            }

            var character = Core.Me.CurrentTarget as Character;
            
            if (SpellsDefine.Wildfire.RecentlyUsed() || Core.Me.HasAura(AurasDefine.WildfireBuff))
            {
                return 2;
            }

            if (SpellsDefine.Wildfire.IsReady() || SpellsDefine.Wildfire.Cooldown.TotalMilliseconds < 15000)
            {
                return -3;
            }

            return 0;
        }

        public async Task<SpellData> Run()
        {
            if (await SpellHelper.CastAbility(SpellsDefine.Hypercharge, Core.Me))
            {
                return SpellsDefine.Hypercharge;
            }

            return null;
        }
    }
}