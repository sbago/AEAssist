using System.Threading.Tasks;
using AEAssist.Define;
using ff14bot.Managers;
using AEAssist.Helper;
using ff14bot.Helpers;
using System.Windows.Media;

namespace AEAssist.AI.Summoner.Ability
{
    
    public class SMNAbility_Deathflare : IAIHandler
    {
        uint spell = SpellsDefine.Deathflare;
        //死星核爆
        public int Check(SpellEntity lastSpell)
        {
            if (SMN_SpellHelper.PhoenixTrance())
            {
                return -4;
            }

            if (!SpellsDefine.Deathflare.IsReady())
                return -1;

            if (ActionResourceManager.Summoner.TranceTimer <= 0 || SMN_SpellHelper.AnyPet())
            {
                return -3;
            }

            

            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            if (await spell.DoAbility()) return spell.GetSpellEntity();

            return null;
        }
    }
}