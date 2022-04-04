using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Objects;

namespace AEAssist.AI
{
    public class BardAbility_Sidewinder : IAIHandler
    {
        public int Check(SpellData lastSpell)
        {
            if (!SpellsDefine.Sidewinder.IsReady())
                return -1;
            if (BardSpellHelper.HasBuffsCount() >= 2)
                return 1;

            if (BardSpellHelper.CheckCanUseBuffs())
            {
                return 2;
            }
            
            if (!Core.Me.HasMyAura(AurasDefine.RagingStrikes))
            {
                return 3;
            }

            if (BardSpellHelper.UnlockBuffsCount() <= 1)
                return 4;

            return -4;
        }

        public async Task<SpellData> Run()
        {
            var spellData = SpellsDefine.Sidewinder;
            if (await SpellHelper.CastAbility(spellData, Core.Me.CurrentTarget))
            {
                return spellData;
            }

            return null;
        }
    }
}