using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist.AI.Samurai.Ability
{
    public class SamuraiAbility_MeikyoShisui : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            //
            if (Core.Me.HasAura(AurasDefine.MeikyoShisui))
                return -13;
            if (Core.Me.IsCasting)
                return -20;
            if (Core.Me.HasAura(AurasDefine.Kaiten))
                return -19;
            if (!SpellsDefine.MeikyoShisui.IsReady())
                return -14;
            if (SamuraiSpellHelper.SenCounts() == 3)
                return -15;
            if (ActionManager.LastSpellId == SpellsDefine.Hakaze || ActionManager.LastSpellId == SpellsDefine.Shifu || ActionManager.LastSpellId == SpellsDefine.Jinpu)
                return -16;
            if (ActionResourceManager.Samurai.Sen.HasFlag(ActionResourceManager.Samurai.Iaijutsu.Setsu))
            {
                return 2;
            }
            return -1;
        }

        public async Task<SpellEntity> Run()
        {
            var spell = SpellsDefine.MeikyoShisui;
            if (await spell.DoAbility())
                return spell.GetSpellEntity();
            return null;
        }
    }
}