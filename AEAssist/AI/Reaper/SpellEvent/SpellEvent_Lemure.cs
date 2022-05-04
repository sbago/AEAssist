using AEAssist.Define;

namespace AEAssist.AI.Reaper.SpellEvent
{
    [SpellEvent(SpellsDefine.LemuresSlice)]
    [SpellEvent(SpellsDefine.LemuresScythe)]
    public class SpellEvent_Lemure : ISpellEvent
    {
        public void Run(uint spellId)
        {
            AIRoot.Instance.MuteAbilityTime();
        }
    }
}