using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot.Managers;

namespace AEAssist.AI.Summoner.Ability
{
    public class SMNAbility_Deathflare : IAIHandler
    {
        
        public int Check(SpellEntity lastSpell)
        {
            if (!SpellsDefine.Deathflare.IsReady())
                return -1;

            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            var spell = SpellsDefine.AstralFlow;
            if (await spell.DoAbility()) return spell.GetSpellEntity();

            return null;
        }
    }
}