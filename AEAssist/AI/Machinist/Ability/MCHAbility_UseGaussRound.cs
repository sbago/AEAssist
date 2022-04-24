using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Objects;

namespace AEAssist.AI.MCH
{
    public class MCHAbility_UseGaussRound : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            if (!SpellsDefine.GaussRound.IsReady() && !SpellsDefine.Ricochet.IsReady())
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
                if (AIRoot.GetBattleData<BattleData>().lastGCDIndex - lastGCDIndex < 2)
                {
                    return -3;
                }
            }

            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            SpellEntity spellData;
            if (SpellsDefine.GaussRound.SpellData.Charges >= SpellsDefine.Ricochet.SpellData.Charges)
                spellData = SpellsDefine.GaussRound;
            else
                spellData = SpellsDefine.Ricochet;
            
            if (await spellData.DoAbility())
            {
                return spellData;
            }

            return null;
        }
    }
}