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
    internal class WhiteMageAbilityDivineBenison : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            if (!SpellsDefine.DivineBenison.IsReady()) return -1;
            var skillTarget = GroupHelper.CastableAlliesWithin30.FirstOrDefault(r => r.CurrentHealth > 0 && r.CurrentHealthPercent <= SettingMgr.GetSetting<WhiteMageSettings>().DivineBenisonHp);
            if (skillTarget == null)
            {
                return -2;
            }
            if (!SpellsDefine.DivineBenison.IsMaxChargeReady())
            {
                return -1;
            }
            return 0;
        }

        public Task<SpellEntity> Run()
        {
            return WhiteMageSpellHelper.CastDivineBenison();
        }
    }
}