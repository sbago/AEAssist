using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Objects;

namespace AEAssist.AI
{
    public class BardAbility_RagingStrikes : IAIHandler
    {
        public bool Check(SpellData lastSpell)
        {
            if (!Spells.RagingStrikes.IsReady())
                return false;
            if (!AIRoot.Instance.Is2ndAbilityTime())
                return false;
            return true;
        }

        public async Task<SpellData> Run()
        {
            var spellData = Spells.RagingStrikes;
            if (await SpellHelper.CastAbility(spellData, Core.Me))
            {
                BardSpellEx.RecordUsingRagingStrikesTime();
                return spellData;
            }

            return null;
        }
    }
}