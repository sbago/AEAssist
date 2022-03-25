using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist.AI
{
    public class BardGCD_ApexArrow : IAIHandler
    {
        public bool Check(SpellData lastSpell)
        {
            if (ActionResourceManager.Bard.SoulVoice >= BardSettings.Instance.ApexArrowValue)
                return true;
            return false;
        }

        public async Task<SpellData> Run()
        {
            var spell = Spells.ApexArrow;
            if (spell == null)
                return null;
            var ret = await SpellHelper.CastGCD(spell, Core.Me.CurrentTarget);
            if (ret)
                return spell;
            return null;
        }
    }
}