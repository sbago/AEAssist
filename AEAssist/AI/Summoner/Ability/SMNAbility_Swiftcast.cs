using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot.Managers;

using ff14bot.Helpers;
using System.Windows.Media;
using ff14bot;

namespace AEAssist.AI.Summoner.Ability
{
    public class SMNAbility_Swiftcast : IAIHandler
    {

        uint spell = SpellsDefine.Swiftcast;
        
        public int Check(SpellEntity lastSpell)
        {
            if (!SpellsDefine.Swiftcast.IsReady())
                return -1;

            if (AIRoot.Instance.CloseBurst)
            {
                return -2;
            }


            if (SMN_SpellHelper.Garuda() && Core.Me.HasAura(AurasDefine.GarudasFavor))
                return 1;
            
            if (SMN_SpellHelper.Ifrit() && SettingMgr.GetSetting<SMNSettings>().SwiftcastOption > 1)  
                return 2; 

            return -99;
        }

        public async Task<SpellEntity> Run()
        {
            if (await spell.DoAbility()) return spell.GetSpellEntity();

            return null;
        }
    }
}