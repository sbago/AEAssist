using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Objects;

namespace AEAssist.AI
{
    /// <summary>
    /// 如果有纷乱buff, 打辉煌
    /// </summary>
    public class BardGCD_Barrage_RefulgentArrow : IAIHandler
    {
        public bool Check(SpellData lastSpell)
        {
            if (!Core.Me.HasAura(AurasDefine.Barrage))
                return false;
            return true;
        }

        public async Task<SpellData> Run()
        {
            var spell = BardSpellEx.GetRefulgentArrow();
            if (spell == null)
                return null;
            var ret = await SpellHelper.CastGCD(spell, Core.Me.CurrentTarget);
            if (ret)
                return spell;
            return null;
        }
    }
}