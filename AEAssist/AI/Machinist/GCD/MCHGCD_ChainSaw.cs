using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Objects;

namespace AEAssist.AI.MCH
{
    public class MCHGCD_ChainSaw : IAIHandler
    {
        public int Check(SpellData lastSpell)
        {
            var ret = MCHSpellHelper.ReadyToUseChainSaw();
            if (ret < 0)
                return ret;
            return 0;
        }

        public async Task<SpellData> Run()
        {
            if (await SpellHelper.CastGCD(SpellsDefine.ChainSaw, Core.Me.CurrentTarget))
            {
                return SpellsDefine.ChainSaw;
            }

            return null;
        }
    }
}