using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;

namespace AEAssist.AI.Samurai.Ability
{
    public class SamuraiAbility_KaeshiSetsugekka : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            if (!SpellsDefine.KaeshiSetsugekka.IsReady()) return -1;
            
            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            var spell = SpellsDefine.KaeshiSetsugekka.GetSpellEntity();
            if (spell == null) return null;
            if (await spell.DoAbility())
                return spell;
            return null;
        }
    }
}