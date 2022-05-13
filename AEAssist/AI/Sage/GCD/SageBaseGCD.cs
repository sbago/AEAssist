using System.Threading.Tasks;
using AEAssist.Define;
using ff14bot.Managers;

namespace AEAssist.AI.Sage.GCD
{
    public class SageBaseGCD : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            // don't cast dosis when moving, instead going to cast other spells.
            if (MovementManager.IsMoving) return -1;
            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            var spell = SageSpellHelper.GetBaseGcd();
            if (spell == null) return null;
            var ret = await spell.DoGCD(); 
            return ret ? spell : null;
        }
    }
}