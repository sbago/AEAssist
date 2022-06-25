using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot.Managers;
using ff14bot;
namespace AEAssist.AI.Summoner.GCD
{
    public class SMNGCD_RuinIV : IAIHandler
    {
        uint spell = SpellsDefine.Ruin4;
       
        public int Check(SpellEntity lastSpell)
        {
            if (!spell.IsReady())
                return -1;
            if ((AIRoot.Instance.CloseBurst||DataBinding.Instance.SaveInstantSpells) && !SpellsDefine.EnergyDrain.CoolDownInGCDs(2))
            {

                return -2;
            }
            if (!Core.Me.HasAura(AurasDefine.FurtherRuin))
                return -10;
            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            if (await spell.DoGCD()) return spell.GetSpellEntity();

            return null;
        }
    }
}