using System.Threading.Tasks;
using AEAssist.AI.Sage;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;

namespace AEAssist.AI.Dancer.Ability
{
    public class DancerAbility_DanceStep : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            if (!Core.Me.HasAura(AurasDefine.StandardStep) && !Core.Me.HasAura(AurasDefine.TechnicalStep))
            {
                return -10;
            }
            var bdls = AIRoot.GetBattleData<BattleData>().lastGCDSpell;
            if (bdls == SpellsDefine.DoubleStandardFinish.GetSpellEntity() ||
                bdls == SpellsDefine.QuadrupleTechnicalFinish.GetSpellEntity())
            {
                return -1;
            }

            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            var SpellEntity = DancerSpellHelper.UseDanceStep();

            if (await SpellEntity.DoAbility()) return SpellEntity;

            return null;
        }
    }
}