using System;
using System.Linq;
using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using Buddy.Coroutines;
using ff14bot;
using ff14bot.Helpers;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist.AI.WhiteMage.Ability
{
    internal class WhiteMageAbilityAssize:IAIHandler
    {

        public int Check(SpellEntity lastSpell)
        {
            //if (!SettingMgr.GetSetting<WhiteMageSettings>().Heal)
            //{
                //return -5;
            //}
            if (!SpellsDefine.Assize.IsReady()) return -1;
            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            var spell = SpellsDefine.Assize.GetSpellEntity();
            if (spell == null) return null;
            var ret = await spell.DoAbility();
            return ret ? spell : null;
        }
    }
}
