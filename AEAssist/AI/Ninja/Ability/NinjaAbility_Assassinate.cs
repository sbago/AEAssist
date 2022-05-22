using System.CodeDom;
using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Objects;

namespace AEAssist.AI.Ninja.Ability
{
    public class NinjaAbility_Assassinate : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            if (!SpellsDefine.Assassinate.IsUnlock())
            {
                return -10;
            }
            var target = Core.Me.CurrentTarget as Character;
            if (SpellsDefine.Assassinate.IsReady() &&
                target.ContainAura(AurasDefine.VulnerabilityTrickAttack))
            {
                return 0;
            }
            return -4;
        }

        public async Task<SpellEntity> Run()
        {
            var spell = SpellsDefine.Assassinate.GetSpellEntity();
            if (spell == null)
                return null;
            var ret = await spell.DoAbility();
            if (ret)
                return spell;
            return null;
        }
    }
}