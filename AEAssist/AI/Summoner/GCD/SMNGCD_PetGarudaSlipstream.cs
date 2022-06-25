using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot.Managers;
using ff14bot;
namespace AEAssist.AI.Summoner.GCD
{
    public class SMNGCD_PetGarudaSlipstream : IAIHandler
    {
        uint spell = SpellsDefine.Slipstream;
        public int Check(SpellEntity lastSpell)
        {
            if (!Core.Me.HasAura(AurasDefine.GarudasFavor))
                return -3;
            if (!spell.IsReady())
                return -1;
            if (SpellsDefine.Swiftcast.IsReady()&&!AIRoot.Instance.CloseBurst)
            {
                return -4;
            }
            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            if (await spell.DoGCD()) return spell.GetSpellEntity();

            return null;
        }
    }
}