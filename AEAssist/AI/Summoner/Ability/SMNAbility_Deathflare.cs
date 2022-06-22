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
        
        public int Check(SpellEntity lastSpell)
        {
            if (DebugSetting.debug)
            {
                Logging.Write(Colors.Red, this.GetType().Name);
            }

            if (!SpellsDefine.Deathflare.IsReady())
                return -1;

            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            var spell = SpellsDefine.Deathflare;
            if (await spell.DoAbility()) return spell.GetSpellEntity();

            return null;
        }
    }
}