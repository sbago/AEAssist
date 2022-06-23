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
        uint spell;
        uint GetEnkindleBahamut()
        {
            if (SMN_SpellHelper.PhoenixTrance() && SpellsDefine.EnkindlePhoenix.IsUnlock())
                return SpellsDefine.EnkindlePhoenix;
            return SpellsDefine.EnkindleBahamut;
        }


        //龙神迸发
        
        public int Check(SpellEntity lastSpell)
        {
            spell = GetEnkindleBahamut();
            if (!spell.IsReady())
                return -1;
            if (ActionResourceManager.Summoner.TranceTimer <= 0 || SMN_SpellHelper.AnyPet())
            {
                return -2;
            }
            if (SMN_SpellHelper.Debugging)
            {
                LogHelper.Debug("trance time:" + ActionResourceManager.Summoner.TranceTimer);
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