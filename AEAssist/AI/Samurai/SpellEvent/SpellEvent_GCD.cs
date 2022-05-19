using AEAssist.Define;
using ff14bot.Managers;
using AEAssist.Helper;

namespace AEAssist.AI.Samurai.SpellEvent
{
    [SpellEvent(SpellsDefine.Higanbana)]
    [SpellEvent(SpellsDefine.KaeshiSetsugekka)]
    [SpellEvent(SpellsDefine.KaeshiNamikiri)]
    [SpellEvent(SpellsDefine.MidareSetsugekka)]
    [SpellEvent(SpellsDefine.OgiNamikiri)]
    [SpellEvent(SpellsDefine.Hakaze)]
    [SpellEvent(SpellsDefine.Shifu)]
    [SpellEvent(SpellsDefine.Gekko)]
    [SpellEvent(SpellsDefine.Kasha)]
    [SpellEvent(SpellsDefine.Yukikaze)]
    [SpellEvent(SpellsDefine.Jinpu)]
    public class SpellEvent_GCD : ISpellEvent
    {
        public void Run(uint spellId)
        {
            var battleData = AIRoot.GetBattleData<SamuraiBattleData>();
            if (spellId == SpellsDefine.KaeshiSetsugekka && DataManager.GetSpellData(SpellsDefine.KaeshiSetsugekka).Cooldown.TotalMilliseconds > 70000)
            {
                int gcd = 0;
                if (ActionManager.LastSpell == DataManager.GetSpellData(SpellsDefine.Hakaze))
                    gcd = 1;

                battleData.GCDCounts = 0+gcd;
                return ;
            }
            battleData.GCDCounts++;
            //LogHelper.Info(battleData.GCDCounts.ToString());
        }
    }
}