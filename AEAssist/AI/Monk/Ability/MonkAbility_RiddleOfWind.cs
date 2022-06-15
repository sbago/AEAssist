using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;

namespace AEAssist.AI.Monk.Ability
{
    public class MonkAbility_RiddleOfWind : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            if (!SpellsDefine.RiddleofWind.IsUnlock())
            {
                return -10;
            }

            if (!SpellsDefine.RiddleofWind.IsReady())
            {
                return -1;
            }

            return 0;
        }

        
        
        public async Task<SpellEntity> Run()
        {
            var spell = SpellsDefine.RiddleofWind.GetSpellEntity();
            if (spell == null)
                return null;
            var ret = await spell.DoAbility();
            if (ret)
                return spell;
            return null;
        }
    }
}