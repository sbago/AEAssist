using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist.AI
{
    public class BardAbility_EmpyrealArrow : IAIHandler
    {
        public bool Check(SpellData lastSpell)
        {
            if (!Spells.EmpyrealArrow.IsReady())
                return false;
            var currSong = ActionResourceManager.Bard.ActiveSong;
            var remainTime = ActionResourceManager.Bard.Timer.TotalMilliseconds;
            switch (currSong)
            {
                case ActionResourceManager.Bard.BardSong.None:
                    return false;
                case ActionResourceManager.Bard.BardSong.MagesBallad:
                    if (remainTime <= BardSettings.Instance.Songs_MB_TimeLeftForSwitch)
                        return false;
                    break;
                case ActionResourceManager.Bard.BardSong.ArmysPaeon:
                    if (remainTime <= BardSettings.Instance.Songs_AP_TimeLeftForSwitch)
                        return false;
                    break;
                case ActionResourceManager.Bard.BardSong.WanderersMinuet:
                    if (remainTime <= BardSettings.Instance.Songs_WM_TimeLeftForSwitch)
                        return false;
                    break;
            }

            return true;
        }

        public async Task<SpellData> Run()
        {
            var spell = Spells.EmpyrealArrow;
            if (spell == null)
                return null;
            var ret = await SpellHelper.CastAbility(spell, Core.Me.CurrentTarget);
            if (ret)
                return spell;
            return null;
        }
    }
}