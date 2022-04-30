using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Objects;

namespace AEAssist.AI
{
    /// <summary>
    ///     如果有纷乱buff, 打辉煌
    /// </summary>
    public class BardGCD_Barrage_RefulgentArrow : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            if (!Core.Me.HasAura(AurasDefine.Barrage))
                return -1;
            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            SpellEntity spell = null;
            // 25和5 是 Shadowbite 的攻击距离和伤害距离
            if (BardSpellHelper.IsShadowBiteReady() && TargetHelper.CheckNeedUseAOE(25, 5, ConstValue.BardAOECount))
            {
                spell = SpellsDefine.Shadowbite.GetSpellEntity();
                if (await spell.DoGCD())
                    return spell;
            }

            spell = BardSpellHelper.GetRefulgentArrow();
            if (spell == null)
                return null;
            var ret = await spell.DoGCD();
            if (ret)
                return spell;
            return null;
        }
    }
}