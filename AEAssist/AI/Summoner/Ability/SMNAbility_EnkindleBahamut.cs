using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot.Managers;

namespace AEAssist.AI.Summoner.Ability
{
    public class SMNAbility_EnkindleBahamut : IAIHandler
    {
        
        public int Check(SpellEntity lastSpell)
        {
            if (!SpellsDefine.EnkindleBahamut.IsReady())
                return -1;

            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            var spell = SpellsDefine.EnkindleBahamut;
            if (await spell.DoAbility()) return spell.GetSpellEntity();

            return null;
        }
    }
}