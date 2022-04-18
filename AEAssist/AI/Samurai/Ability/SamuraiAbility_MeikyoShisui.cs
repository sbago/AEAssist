using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist.AI
{
    public class SamuraiAbility_MeikyoShisui : IAIHandler
    {
        public int Check(SpellData lastSpell)
        {
            var ta = Core.Me.CurrentTarget as Character;
            if (ActionResourceManager.Samurai.Sen.HasFlag(ActionResourceManager.Samurai.Iaijutsu.Setsu) &&
                (SamuraiSpellHelper.SenCounts() != 0) &&
                !Core.Me.HasAura(AurasDefine.MeikyoShisui) &&
                ((SpellsDefine.KaeshiSetsugekka.Cooldown.TotalMilliseconds % 60000) > 40000 ) && 
                !(ta.GetAuraById(AurasDefine.Higanbana)?.TimeLeft < 5) &&
                (ActionManager.LastSpell == null ))
                return 1;

            return -1;
        }

        public async Task<SpellData> Run()
        {
            var spell = SpellsDefine.MeikyoShisui;
            if(await SpellHelper.CastAbility(spell, Core.Me.CurrentTarget))
                return spell;
            return null;
        }
    }
}
