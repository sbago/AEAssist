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
            if (!SpellsDefine.ChainSaw.IsReady())
                return -1;
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