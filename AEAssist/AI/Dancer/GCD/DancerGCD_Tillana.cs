using System.Threading.Tasks;
using AEAssist.AI.Dancer.SpellQueue;
using AEAssist.AI.Sage;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;

namespace AEAssist.AI.Dancer.GCD
{
    public class DancerGCD_Tillana : IAIHandler
    {
        public int Check(SpellEntity lastGCD)
        {
            if (!SpellsDefine.Tillana.IsUnlock())
            {
                return -10;
            }

            if (Core.Me.CurrentTarget.Distance(Core.Me) > 15)
            {
                return -1;
            }

            if (Core.Me.HasAura(AurasDefine.FlourishingFinish))
            {
                return 1;
            }
            return -4;
        }

        public async Task<SpellEntity> Run()
        {
            var spell = SpellsDefine.Tillana.GetSpellEntity();
            if (spell == null)
                return null;
            var ret = await spell.DoGCD();
            if (ret)
                return spell;
            return null;
        }
    }
}