using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist.AI
{
    public class BardAbility_PitchPerfect : IAIHandler
    {
        public bool Check(SpellData lastSpell)
        {
            if (!Spells.PitchPerfect.IsReady())
                return false;
            if (ActionResourceManager.Bard.ActiveSong != ActionResourceManager.Bard.BardSong.WanderersMinuet)
                return false;

            if (ActionResourceManager.Bard.Repertoire == 0)
                return false;

            var time = ActionResourceManager.Bard.Timer.TotalMilliseconds;

            if (time - BardSpellEx.TimeUntilNextPossibleDoTTick() < 550)
                return true;

            if (ActionResourceManager.Bard.Repertoire == 3)
                return true;

            return false;
        }

        public async Task<SpellData> Run()
        {
            var spell = Spells.PitchPerfect;
            if (spell == null)
                return null;
            var ret = await SpellHelper.CastAbility(spell, Core.Me.CurrentTarget);
            if (ret)
                return spell;
            return null;
        }
    }
}