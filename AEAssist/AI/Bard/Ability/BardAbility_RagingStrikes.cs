using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Objects;

namespace AEAssist.AI
{
    public class BardAbility_RagingStrikes : IAIHandler
    {
        public int Check(SpellData lastSpell)
        {
            if (AIRoot.Instance.BurstOff)
                return -1;
            if (!SpellsDefine.RagingStrikes.IsReady())
                return -2;
            if (TTKHelper.IsTargetTTK(Core.Me.CurrentTarget as Character))
                return -3;
            if (SpellsDefine.TheWanderersMinuet.IsUnlock() && !SpellsDefine.TheWanderersMinuet.RecentlyUsed() &&
                !Core.Me.ContainMyAura(AurasDefine.TheWanderersMinuet))
                return -4;
            return 0;
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