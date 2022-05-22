using System.Threading.Tasks;
using AEAssist.AI.Dancer.SpellQueue;
using AEAssist.AI.Sage;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;

namespace AEAssist.AI.Dancer.GCD
{
    public class DancerGCD_SaberDance : IAIHandler
    {
        public int Check(SpellEntity lastGCD)
        {
            if (!SpellsDefine.SaberDance.IsUnlock())
            {
                return -10;
            }
            if (AIRoot.Instance.CloseBurst)
                return -5;
            if (Core.Me.HasAura(AurasDefine.StandardStep) ||
                Core.Me.HasAura(AurasDefine.TechnicalStep))
            {
                return -2;
            }
            if (ActionResourceManager.Dancer.Esprit < 50)
            {
                return -1;
            }
            if (AEAssist.DataBinding.Instance.FinalBurst) return 2;

            if (Core.Me.HasAura(AurasDefine.Devilment))
            {
                return 0;
            }
            if (ActionResourceManager.Dancer.Esprit >= 85)
            {
                return 1;
            }
            return -4;
        }

        public async Task<SpellEntity> Run()
        {
            var spell = SpellsDefine.SaberDance.GetSpellEntity();
            if (spell == null)
                return null;
            var ret = await spell.DoGCD();
            if (ret)
                return spell;
            return null;
        }
    }
}