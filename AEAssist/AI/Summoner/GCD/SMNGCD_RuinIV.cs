using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot.Managers;
using ff14bot;
namespace AEAssist.AI.Summoner.GCD
{
    public class SMNGCD_RuinIV : IAIHandler
    {
       
        public int Check(SpellEntity lastSpell)
        {
            if (!SpellsDefine.Ruin4.IsReady())
                return -1;
            if (AIRoot.Instance.CloseBurst && !SpellsDefine.EnergyDrain.CoolDownInGCDs(2))
            {

                return -2;
            }
            if (!Core.Me.HasAura(AurasDefine.FurtherRuin))
                return -10;
            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            var spell = SpellsDefine.Ruin4.GetSpellEntity();

            if (await spell.DoGCD()) return spell;

            return null;
        }
    }
}