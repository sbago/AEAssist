using System.Threading.Tasks;
using AEAssist.AI.Sage;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;

namespace AEAssist.AI.Dancer.GCD
{
    public class DancerGCD_Procs : IAIHandler
    {
        public int Check(SpellEntity lastGCD)
        {
            if (!SpellsDefine.ReverseCascade.IsUnlock())
            {
                return -10;
            }
            if (!Core.Me.HasAura(AurasDefine.FlourishingSymmetry) &&
                !Core.Me.HasAura(AurasDefine.FlourshingFlow))
            {
                return -1;
            }
            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            // var spell = SpellsDefine.StandardStep.GetSpellEntity();
            return await DancerSpellHelper.ProcGCDCombo(Core.Me.CurrentTarget);
        }
    }
}