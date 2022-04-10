using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Objects;

namespace AEAssist.AI
{
    public class BardAbility_EmpyrealArrow : IAIHandler
    {
        public int Check(SpellData lastSpell)
        {
            if (!SpellsDefine.EmpyrealArrow.IsReady())
                return -1;
            if (BardSpellHelper.PrepareSwitchSong())
                return -2;

            return 0;
        }

        public async Task<SpellData> Run()
        {
            var spell = SpellsDefine.EmpyrealArrow;
            if (spell == null)
                return null;
            var ret = await SpellHelper.CastAbility(spell, Core.Me.CurrentTarget);
            if (ret)
                return spell;
            return null;
        }
    }
}