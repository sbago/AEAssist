using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;

namespace AEAssist.AI.WhiteMage.Ability
{
    internal class WhiteMageAbilityTetragrammaton:IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            if (!SpellsDefine.Tetragrammaton.IsReady()) return -1;
            
            return 0;
        }

        public Task<SpellEntity> Run()
        {
            return WhiteMageSpellHelper.CastTetragrammatonPriority();
        }
    }
}
