using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot.Managers;

using ff14bot.Helpers;
using System.Windows.Media;
namespace AEAssist.AI.Summoner.Ability
{
    public class SMNAbility_EnkindleBahamut : IAIHandler
    {
        
        public int Check(SpellEntity lastSpell)
        {
            if (DebugSetting.debug)
            {
                Logging.Write(Colors.Red, this.GetType().Name);
            }
            if (!SpellsDefine.EnkindleBahamut.IsReady())
                return -1;

            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            var spell = SpellsDefine.EnkindleBahamut;
            if (await spell.DoAbility()) return spell.GetSpellEntity();

            return null;
        }
    }
}