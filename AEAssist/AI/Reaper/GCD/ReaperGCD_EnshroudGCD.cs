using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist.AI.Reaper.GCD
{
    public class ReaperGCD_EnshroudGCD : IAIHandler
    {
        public bool Check(SpellData lastSpell)
        {
            if (!SpellsDefine.CrossReaping.IsUnlock())
                return false;

            if (!Core.Me.HasAura(AurasDefine.Enshrouded))
                return false;

            if (ActionResourceManager.Reaper.LemureShroud == 0)
                return false;

            // 本来需要打90大招,但是因为在移动,所以不打了.
            if (ActionResourceManager.Reaper.LemureShroud < 2 
                && SpellsDefine.Communio.IsUnlock()
            && MovementManager.IsMoving)
                return false;

            return true;
        }

        public async Task<SpellData> Run()
        {
            var spell = ReaperSpellHelper.GetEnshroudGCDSpell(Core.Me.CurrentTarget);
            if (spell == null)
                return null;
            if (spell == SpellsDefine.Communio)
            {
                MovementManager.MoveStop();
            }

            if (await SpellHelper.CastGCD(spell, Core.Me.CurrentTarget))
            {
                return spell;
            }

            return null;
        }
    }
}