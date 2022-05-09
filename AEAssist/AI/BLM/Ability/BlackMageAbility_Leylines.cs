using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;

namespace AEAssist.AI.Bard.Ability
{
    public class BlackMageAblity_Leylines : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            if (!SpellsDefine.LeyLines.IsReady())
            {
                return -1;
            }

            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            var spell = SpellsDefine.LeyLines.GetSpellEntity();
            if (spell == null)
                return null;
            var ret = await spell.DoAbility();
            if (ret)
                return spell;
            return null;
        }
    }
}