using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;

namespace AEAssist.AI.WhiteMage.Ability
{
    internal class WhiteMageAbilityAssize:IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            if (!SpellsDefine.Assize.IsReady()) return -1;
            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            var spell = SpellsDefine.Assize.GetSpellEntity();
            if (spell == null) return null;
            var ret = await spell.DoAbility();
            return ret ? spell : null;
        }
    }
}
