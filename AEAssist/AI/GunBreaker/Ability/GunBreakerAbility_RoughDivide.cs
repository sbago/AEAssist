using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;

namespace AEAssist.AI.GunBreaker.Ability
{
    public class GunBreakerAbility_RoughDivide : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            if (SpellsDefine.RoughDivide.GetSpellEntity().SpellData.Charges < 1.9)
                return -1;
            return 0;
        }
        public async Task<SpellEntity> Run()
        {
            var spell = SpellsDefine.RoughDivide.GetSpellEntity();
            if (spell == null) return null;
            if (await spell.DoAbility())
                return spell;
            return null;
        }
    }
}
