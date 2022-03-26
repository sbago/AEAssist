using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Objects;

namespace AEAssist.AI
{
    public class BardAbility_Sidewinder : IAIHandler
    {
        public bool Check(SpellData lastSpell)
        {
            if (!Spells.Sidewinder.IsReady())
                return false;
            if (BardSpellEx.HasBuffsCount() >= 2)
                return true;

            if (BardSpellEx.CheckCanUseBuffs())
            {
                return true;
            }
            
            if (!Core.Me.HasMyAura(AurasDefine.RagingStrikes))
            {
                return true;
            }

            if (BardSpellEx.UnlockBuffsCount() <= 1)
                return true;

            return false;
        }

        public async Task<SpellData> Run()
        {
            var spellData = Spells.Sidewinder;
            if (await SpellHelper.CastAbility(spellData, Core.Me.CurrentTarget))
            {
                return spellData;
            }

            return null;
        }
    }
}