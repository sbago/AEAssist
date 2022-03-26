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
            SpellData spell = null;
            // 25和5 是 Shadowbite 的攻击距离和伤害距离
            if (Spells.Shadowbite.IsReady() && TargetHelper.CheckNeedUseAOE(25, 5, ConstValue.BardAOECount))
            {
                spell = Spells.Shadowbite;
                if (await SpellHelper.CastGCD(spell, Core.Me.CurrentTarget))
                    return spell;
            }

            spell = BardSpellEx.GetRefulgentArrow();
            if (spell == null)
                return null;
            var ret = await SpellHelper.CastGCD(spell, Core.Me.CurrentTarget);
            if (ret)
                return spell;
            return null;
        }
    }
}