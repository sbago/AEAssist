using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;

namespace AEAssist.AI.Monk.Ability
{
    public class MonkAbility_SetPosition : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            return 0;
        }

        
        
        public async Task<SpellEntity> Run()
        {
            //
            // var spell = SpellsDefine.Brotherhood.GetSpellEntity();
            // if (spell == null)
            //     return null;
            // var ret = await spell.DoAbility();
            // if (ret)
            //     return spell;
            MonkSpellHelper.SetPostion();
            return null;
        }
    }
}