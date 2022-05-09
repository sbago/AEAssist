using System.Threading.Tasks;
using AEAssist.AI.BLM.SpellQueue;
using AEAssist.Define;
using AEAssist.Helper;

namespace AEAssist.AI.BLM.GCD
{
    public class BLM_BaseGCD : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            AISpellQueueMgr.Instance.Apply<SpellQueue_Test>();
            await Task.CompletedTask;
            return null;
        }
    }
}