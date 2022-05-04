using AEAssist.Define;
using AEAssist.Helper;
using ff14bot.Managers;

namespace AEAssist.AI.Bard.SpellEvent
{
    [SpellEvent(SpellsDefine.TheWanderersMinuet)]
    [SpellEvent(SpellsDefine.MagesBallad)]
    [SpellEvent(SpellsDefine.ArmysPaeon)]
    public class SpellEvent_Songs : ISpellEvent
    {
        public void Run(uint spellId)
        {
            var battleData = AIRoot.GetBattleData<BardBattleData>();
            battleData.lastCastSongTime = TimeHelper.Now();
            if (spellId == SpellsDefine.TheWanderersMinuet)
                battleData.lastSong = ActionResourceManager.Bard.BardSong.WanderersMinuet;
            else if (spellId == SpellsDefine.MagesBallad)
                battleData.lastSong = ActionResourceManager.Bard.BardSong.MagesBallad;
            else
                battleData.lastSong = ActionResourceManager.Bard.BardSong.ArmysPaeon;
        }
    }
}