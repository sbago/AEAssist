using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot.Managers;

namespace AEAssist.AI.Samurai.Ability
{
    public class SamuraiAbility_KaeshiNamikiri : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            if (!SpellsDefine.KaeshiNamikiri.IsReady()) return -1;
            
            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            var spell = SpellsDefine.KaeshiNamikiri.GetSpellEntity();
            if (spell == null) return null;
            if (await spell.DoAbility())
                return spell;
            return null;
        }
    }
}