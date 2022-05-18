using System.Threading.Tasks;
using AEAssist.AI.Dancer.SpellQueue;
using AEAssist.AI.Sage;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;

namespace AEAssist.AI.Dancer.GCD
{
    public class DancerGCD_StandardStep : IAIHandler
    {
        public int Check(SpellEntity lastGCD)
        {
            if (!SpellsDefine.StandardStep.IsReady())
            {
                return -1;
            }

            if (Core.Me.HasAura(AurasDefine.StandardStep))
            {
                return -2;
            }
            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            // Cascade 瀑泻 ST1 Reverse Cascade 逆瀑泻
            // Fountain 喷泉 ST2 :Fountainfall 坠喷泉 
            // Windmill 风车 AOE1 Rising Windmill 升风车 
            // Bladeshower 落刃雨 AOE2 :Bloodshower 落血雨 
            AISpellQueueMgr.Instance.Apply<SpellQueue_StandardStep>();
            await Task.CompletedTask;
            return null;
            var spell = SpellsDefine.StandardStep.GetSpellEntity();
            if (spell == null)
                return null;
            var ret = await spell.DoGCD();
            if (ret)
                return spell;
            return null;
        }
    }
}