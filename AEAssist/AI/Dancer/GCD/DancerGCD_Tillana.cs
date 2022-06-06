using System.Threading.Tasks;
using AEAssist.AI.Dancer.SpellQueue;
using AEAssist.AI.Sage;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;
using ff14bot.Objects;
using ff14bot.RemoteWindows;

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

            if (!Core.Me.HasAura(AurasDefine.FlourishingFinish))
            {
                return -10;
            }

            // if (Core.Me.CurrentTarget.Distance(Core.Me) > 15)
            // {
            //     return -1;
            // }
            
            if (!Core.Me.HasMyAuraWithTimeleft(AurasDefine.FlourishingFinish, 5000))
            {
                return 2;
            }
            if (!Core.Me.HasAura(AurasDefine.Devilment))
            {
                return -2;
            }
            return 0;
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