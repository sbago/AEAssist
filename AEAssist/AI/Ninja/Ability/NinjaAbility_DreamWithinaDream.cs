using System.CodeDom;
using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Objects;

namespace AEAssist.AI.Ninja.Ability
{
    public class NinjaAbility_DreamWithinaDream : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            if (!SpellsDefine.DreamWithinaDream.IsUnlock())
            {
                return -10;
            }
            var target = Core.Me.CurrentTarget as Character;
            if (SpellsDefine.DreamWithinaDream.IsReady() &&
                target.ContainAura(AurasDefine.VulnerabilityTrickAttack))
            {
                return 0;
            }
            return -4;
        }

        public async Task<SpellEntity> Run()
        {
            var spell = SpellsDefine.DreamWithinaDream.GetSpellEntity();
            if (spell == null)
                return null;
            var ret = await spell.DoAbility();
            if (ret)
                return spell;
            return null;
        }
    }
}