using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist.AI
{
    public class SamuraiAbility_HissatsuSenei : IAIHandler
    {
        public int Check(SpellData lastSpell)
        {
            if (ActionResourceManager.Samurai.Kenki >=25 && 
                SpellsDefine.HissatsuSenei.Cooldown.TotalSeconds == 0 &&
                Core.Me.HasAura(AurasDefine.Shifu))
                return 1;
            return -1;
        }

        public async Task<SpellData> Run()
        {
            var spell = SpellsDefine.HissatsuSenei;
            if (await SpellHelper.CastAbility(spell, Core.Me.CurrentTarget))
                return spell;
            return null;
        }
    }
}
