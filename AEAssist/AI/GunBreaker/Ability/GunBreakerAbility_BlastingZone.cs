using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;

namespace AEAssist.AI.GunBreaker.Ability
{
    public class GunBreakerAbility_BlastingZone : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            if (!SpellsDefine.BlastingZone.IsReady())
                return -1;
            if (SpellsDefine.NoMercy.GetSpellEntity().SpellData.Charges < 0.9)
                return 1;
            if(!SpellsDefine.NoMercy.CoolDownInGCDs(2))
                return -2;
            return 0;
        }
        public async Task<SpellEntity> Run()
        {
            var spell = SpellsDefine.BlastingZone.GetSpellEntity();
            if (spell == null) return null;
            if (await spell.DoAbility())
                return spell;
            return null;
        }
    }
}
