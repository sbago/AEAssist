using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Objects;

namespace AEAssist.AI.Reaper
{
    public class ReaperAbility_TrueNorth : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            if (!DataBinding.Instance.UseTrueNorth)
                return -10;

            if (!SpellsDefine.TrueNorth.IsReady())
                return -1;

            if (Core.Me.HasAura(AurasDefine.TrueNorth)
                || SpellsDefine.TrueNorth.RecentlyUsed())
                return -9;

            if (!SpellsDefine.Gibbet.IsUnlock()) return -2;

            if (!SpellsDefine.BloodStalk.RecentlyUsed()
                && !Core.Me.HasAura(AurasDefine.SoulReaver)
                && !SpellsDefine.Gluttony.RecentlyUsed()
                && !SpellsDefine.GrimSwathe.RecentlyUsed())
                return -3;

            var spell = ReaperSpellHelper.Gibbit_Gallows(Core.Me.CurrentTarget);
            if (spell == null)
                return -4;

            if (spell == SpellsDefine.Gibbet && !Core.Me.CurrentTarget.IsFlanking)
                return 1;

            if (spell == SpellsDefine.Gallows && !Core.Me.CurrentTarget.IsBehind)
                return 2;

            return -5;
        }

        public async Task<SpellEntity> Run()
        {
            var spell = SpellsDefine.TrueNorth;
            if (await spell.DoAbility()) return spell;

            return null;
        }
    }
}