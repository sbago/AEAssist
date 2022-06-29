using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot.Managers;

namespace AEAssist.AI.Samurai.Ability
{
    public class SamuraiAbility_HissatsuYaten : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            
            if (!SpellsDefine.HissatsuYaten.IsReady()) return -1;
            if (ActionResourceManager.Samurai.Kenki < 10) return -1;
            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            var spell = SpellsDefine.HissatsuYaten.GetSpellEntity();
            if (spell == null) return null;
            if (await spell.DoAbility())
                return spell;
            return null;
        }
    }
}