using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist.AI
{
    public class SamuraiGCD_Kaeshi : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            if (AIRoot.GetBattleData<SamuraiBattleData>().KaeshiSpell != KaeshiSpell.NoUse)
                return 10;
            return -1;
        }

        public async Task<SpellEntity> Run()
        {
            var spell = SamuraiSpellHelper.KaeshiCanSpell();
            if (spell == null) return null;
            if (await spell.DoGCD())
            {
                AIRoot.GetBattleData<SamuraiBattleData>().KaeshiSpell = KaeshiSpell.NoUse;
                return spell;
            }
            return null;
        }
    }
}
