using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Objects;

namespace AEAssist.AI
{
    public class BardAbility_RagingStrikes : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            if (AIRoot.Instance.CloseBurst)
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

        public async Task<SpellEntity> Run()
        {
            // if (!AIRoot.Instance.Is2ndAbilityTime())
            //     return null;
            var SpellEntity = SpellsDefine.RagingStrikes;
            if (await SpellEntity.DoAbility())
            {
                BardSpellHelper.RecordUsingRagingStrikesTime();
                return SpellEntity;
            }

            return null;
        }
    }
}