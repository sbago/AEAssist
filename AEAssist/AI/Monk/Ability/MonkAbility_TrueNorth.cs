using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Objects;

namespace AEAssist.AI.Monk.Ability
{
    public class MonkAbility_TrueNorth : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            if (!AEAssist.DataBinding.Instance.UseTrueNorth)
                return -10;

            if (!SpellsDefine.TrueNorth.IsReady())
                return -1;

            if (Core.Me.HasAura(AurasDefine.TrueNorth)
                || SpellsDefine.TrueNorth.RecentlyUsed())
                return -9;
            

            //alway use in the second half of GCD
            if (!AIRoot.Instance.Is2ndAbilityTime())
                return -11;

            if (MonkSpellHelper.InCoeurlForm())
            {
                var target = Core.Me.CurrentTarget as Character;
                var spell = MonkSpellHelper.GetCoeurlGCDS(target);
                if (spell == SpellsDefine.SnapPunch.GetSpellEntity() && !target.IsFlanking)
                {
                    return 1;
                }
                if (spell == SpellsDefine.Demolish.GetSpellEntity() && !target.IsBehind)
                {
                    return 1;
                }
            }

            return -5;
        }

        public async Task<SpellEntity> Run()
        {
            var spell = SpellsDefine.TrueNorth.GetSpellEntity();
            if (await spell.DoAbility()) return spell;

            return null;
        }
    }
}