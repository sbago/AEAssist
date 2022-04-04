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
            if (AIRoot.Instance.CloseBuff)
                return false;
            if (!SpellsDefine.RagingStrikes.IsReady())
                return false;
            if (TTKHelper.IsTargetTTK(Core.Me.CurrentTarget as Character))
                return false;
            if (SpellsDefine.TheWanderersMinuet.IsUnlock() && !Core.Me.ContainMyAura(AurasDefine.TheWanderersMinuet))
                return false;
            return true;
        }

        public async Task<SpellData> Run()
        {
            // if (!AIRoot.Instance.Is2ndAbilityTime())
            //     return null;
            var spellData = SpellsDefine.RagingStrikes;
            if (await SpellHelper.CastAbility(spellData, Core.Me))
            {
                BardSpellHelper.RecordUsingRagingStrikesTime();
                return spellData;
            }

            return null;
        }
    }
}