using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Objects;

namespace AEAssist.AI
{
    public class MCHAbility_UseGaussRound : IAIHandler
    {
        public int Check(SpellData lastSpell)
        {
            if (!SpellsDefine.GaussRound.IsChargeReady() && !SpellsDefine.Ricochet.IsChargeReady())
                return -1;

            if (SpellsDefine.GaussRound.IsMaxChargeReady() || SpellsDefine.Ricochet.IsMaxChargeReady())
            {
                return 1;
            }

            if (SpellsDefine.BarrelStabilizer.IsUnlock())
            {
                if (SpellsDefine.BarrelStabilizer.IsReady())
                    return -2;
                var lastGCDIndex = SpellHistoryHelper.GetLastGCDIndex(SpellsDefine.BarrelStabilizer.Id);
                if (AIRoot.Instance.BattleData.lastGCDIndex - lastGCDIndex < 2)
                {
                    return -3;
                }
            }

            return 0;
        }

        public async Task<SpellData> Run()
        {
            SpellData spellData;
            if (SpellsDefine.GaussRound.Charges >= SpellsDefine.Ricochet.Charges)
                spellData = SpellsDefine.GaussRound;
            else
                spellData = SpellsDefine.Ricochet;
            
            if (await SpellHelper.CastAbility(spellData, Core.Me.CurrentTarget))
            {
                return spellData;
            }

            return null;
        }
    }
}