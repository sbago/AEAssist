using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist.AI
{
    public class MCHAbility_Reassemble : IAIHandler
    {
        public int Check(SpellData lastSpell)
        {
            if (!SpellsDefine.Reassemble.IsChargeReady())
                return -1;
            if (ActionResourceManager.Machinist.OverheatRemaining.TotalMilliseconds > 0)
                return -10;
            if (SpellsDefine.ChainSaw.IsReady())
            {
                if (MCHSpellHelper.ReadyToUseChainSaw() > 0)
                    return 1;
                return -2;
            }
            if (!SpellsDefine.AirAnchor.IsUnlock())
            {
                if (SpellsDefine.Drill.IsReady())
                    return 2;
            }
            else
            {
                if (SpellsDefine.AirAnchor.IsReady())
                    return 3;
                if (SpellsDefine.Drill.IsReady())
                    return 4;
            }

            return -2;

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