using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Objects;

namespace AEAssist.AI
{
    public class BardAbility_Buffs : IAIHandler
    {
        public bool Check(SpellData lastSpell)
        {
            if (AIRoot.Instance.CloseBuff)
                return false;
            var tar = Core.Me.CurrentTarget as Character;
            if (TTKHelper.IsTargetTTK(tar))
                return false;
            if (!BardSpellHelper.CheckCanUseBuffs())
                return false;
            // if (!tar.IsBoss())
            // {
            //     return false;
            // }
            // if (BardSpellEx.IsBuff(lastSpell))
            //     return false;
            var buffs = BardSpellHelper.GetBuffs();
            if (buffs == null)
                return false;
            return true;
        }

        public async Task<SpellData> Run()
        {
            // if (!AIRoot.Instance.Is2ndAbilityTime())
            //     return null;
            var buff = BardSpellHelper.GetBuffs();
            if (buff == null)
                return null;
            var ret = await SpellHelper.CastAbility(buff, Core.Me,0);
            if (ret)
            {
                var lastBuff = buff;
                // buff = BardSpellEx.GetBuffs();
                // // 连续使用两个Buff
                // if(buff != null)
                // {
                //     if (await SpellHelper.CastAbility(buff, Core.Me, 0))
                //     {
                //         AIRoot.Instance.MuteAbilityTime();
                //         return buff;
                //     }
                // }
                return lastBuff;
            }

            return null;
        }
    }
}