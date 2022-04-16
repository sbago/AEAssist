using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Objects;

namespace AEAssist.AI.MCH
{
    public class MCHGCD_AirAnchor : IAIHandler
    {
        public int Check(SpellData lastSpell)
        {
            var spell = MCHSpellHelper.GetAirAnchor();
            if (spell == null || !spell.IsReady())
                return -1;
            

            // 只有热弹的时候,给钻头让路
            if (spell == SpellsDefine.HotShot && SpellsDefine.Drill.IsReady())
                return -2;
            
            return 0;
        }

        public async Task<SpellData> Run()
        {
            var spell = MCHSpellHelper.GetAirAnchor();
            
            if (await SpellHelper.CastGCD(spell, Core.Me.CurrentTarget))
            {
                return spell;
            }

            return null;
        }
    }
}