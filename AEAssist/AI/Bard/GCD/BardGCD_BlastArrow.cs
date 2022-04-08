using System.Threading.Tasks;
using AEAssist;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Objects;

namespace AEAssist.AI
{
    public class BardGCD_BlastArrow : IAIHandler
    {
        public int Check(SpellData lastSpell)
        {
            if (!AEAssist.DataBinding.Instance.UseApex)
                return -1;
            if (!Core.Me.HasAura(AurasDefine.BlastArrowReady))
                return -2;

            if (BardSpellHelper.HasBuffsCount() >= BardSpellHelper.UnlockBuffsCount())
                return 1;

            var aura = Core.Me.GetAuraById(AurasDefine.BlastArrowReady);
            if (BardSpellHelper.Prepare2BurstBuffs((int) aura.TimespanLeft.TotalMilliseconds + + ConstValue.AuraTick))
                return -3;
            var buffTime = SpellsDefine.RagingStrikes.Cooldown.TotalMilliseconds;
            if (SpellsDefine.RagingStrikes.IsReady())
                buffTime = 0;
            if (aura.TimespanLeft.TotalMilliseconds >= buffTime + ConstValue.AuraTick * 2)
            {
                return -4;
            }

            return 0;
        }

        public async Task<SpellData> Run()
        {
            var spell = BardSpellHelper.GetBlastArrow();
            if (spell == null)
                return null;
            var ret = await SpellHelper.CastGCD(spell, Core.Me.CurrentTarget);
            if (ret)
                return spell;
            return null;
        }
    }
}