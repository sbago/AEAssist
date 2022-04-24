using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Objects;

namespace AEAssist.AI.MCH
{
    public class MCHGCD_AirAnchor : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            var spell = MCHSpellHelper.GetAirAnchor();
            if (spell == null || !spell.IsReady())
                return -1;
            

            // 只有热弹的时候,给钻头让路
            if (spell == SpellsDefine.HotShot && SpellsDefine.Drill.IsReady())
                return -2;
            
            // 整备只有1层的时候,如果5秒内能冷却好,等一下
            if (!SpellsDefine.Reassemble.RecentlyUsed() && SpellsDefine.Reassemble.SpellData.MaxCharges < 1.5f && SpellsDefine.Reassemble.Cooldown.TotalMilliseconds < 5000)
            {
                return -3;
            }

            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            var spell = MCHSpellHelper.GetAirAnchor();
            
            if (await spell.DoGCD())
            {
                return spell;
            }

            return null;
        }
    }
}