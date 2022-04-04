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
        public int Check(SpellData lastSpell)
        {
            if (!SpellsDefine.EmpyrealArrow.IsReady())
                return -1;
            var currSong = ActionResourceManager.Bard.ActiveSong;
            var remainTime = ActionResourceManager.Bard.Timer.TotalMilliseconds;
            switch (currSong)
            {
                case ActionResourceManager.Bard.BardSong.None:
                    return -2;
                case ActionResourceManager.Bard.BardSong.MagesBallad:
                    if (remainTime <= SettingMgr.GetSetting<BardSettings>().Songs_MB_TimeLeftForSwitch)
                        return -3;
                    break;
                case ActionResourceManager.Bard.BardSong.ArmysPaeon:
                    if (remainTime <= SettingMgr.GetSetting<BardSettings>().Songs_AP_TimeLeftForSwitch)
                        return -4;
                    break;
            }

            return 0;
        }

        public async Task<SpellData> Run()
        {
            var spell = SpellsDefine.EmpyrealArrow;
            if (spell == null)
                return null;
            var ret = await SpellHelper.CastAbility(spell, Core.Me.CurrentTarget);
            if (ret)
                return spell;
            return null;
        }
    }
}