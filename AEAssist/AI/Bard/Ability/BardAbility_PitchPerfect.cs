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
            if (!SpellsDefine.PitchPerfect.IsReady())
                return false;
            if (ActionResourceManager.Bard.ActiveSong != ActionResourceManager.Bard.BardSong.WanderersMinuet)
                return false;

            if (ActionResourceManager.Bard.Repertoire == 0)
                return false;

            var time = ActionResourceManager.Bard.Timer.TotalMilliseconds;

            if (time < ConstValue.AuraTick)
                return true;

            if (ActionResourceManager.Bard.Repertoire == 3)
                return true;

            var lat = SettingMgr.GetSetting<GeneralSettings>().ActionQueueMs +
                      SettingMgr.GetSetting<GeneralSettings>().UserLatencyOffset;
            
            // 诗心两层,马上要跳诗心了,九天又转好,两个诗心也打出去
            if (ActionResourceManager.Bard.Repertoire == 2
                && BardSpellHelper.TimeUntilNextPossibleDoTTick() <= lat
                && SpellsDefine.EmpyrealArrow.IsReady())

                return true;
                
                
            return false;
        }

        public async Task<SpellData> Run()
        {
            var spell = SpellsDefine.PitchPerfect;
            if (spell == null)
                return null;
            var ret = await SpellHelper.CastAbility(spell, Core.Me.CurrentTarget);
            if (ret)
                return spell;
            return null;
        }
    }
}