using System.Threading.Tasks;
using AEAssist.AI.BlackMage.SpellQueue;
using AEAssist.Define;
using AEAssist.Helper;

namespace AEAssist.AI.BlackMage.GCD
{
    public class BlackMage_BaseGCD : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            AISpellQueueMgr.Instance.Apply<SpellQueue_DespairManafont>();
            await Task.CompletedTask;
            return null;
        }
    }
}