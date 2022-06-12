using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;

namespace AEAssist.AI.Monk.Ability
{
    public class MonkAbility_RiddleOfFire : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            if (!SpellsDefine.RiddleofFire.IsUnlock())
            {
                return -10;
            }

            if (!SpellsDefine.RiddleofFire.IsReady())
            {
                return -1;
            }
            
            if (!AIRoot.Instance.Is2ndAbilityTime())
                return -11;

            return 0;
        }

        
        
        public async Task<SpellEntity> Run()
        {
            var spell = SpellsDefine.RiddleofFire.GetSpellEntity();
            if (spell == null)
                return null;
            var ret = await spell.DoAbility();
            if (ret)
                return spell;
            return null;
        }
    }
}