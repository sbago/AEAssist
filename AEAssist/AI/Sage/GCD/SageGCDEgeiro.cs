using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;

namespace AEAssist.AI.Sage.GCD
{
    public class SageGCDEgeiro : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            LogHelper.Debug("Checking if swiftcast is ready");
            if (!SpellsDefine.Swiftcast.IsReady()) return -5;
            LogHelper.Debug("checking if allies are dead");
            if (GroupHelper.DeadAllies.Count == 0) return -4;
            return 0;
        }

        public Task<SpellEntity> Run()
        {
            return SageSpellHelper.CastResPriority();
        }
    }
}