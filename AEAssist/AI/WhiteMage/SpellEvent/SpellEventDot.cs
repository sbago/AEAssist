using AEAssist.Define;

namespace AEAssist.AI.WhiteMage.SpellEvent
{
    [SpellEvent(SpellsDefine.Aero)]
    [SpellEvent(SpellsDefine.Aero2)]
    [SpellEvent(SpellsDefine.Dia)]
    public class SpellEventDot : ISpellEvent
    {
        public void Run(uint spellId)
        {
            if (spellId == SpellsDefine.Aero ||
                spellId == SpellsDefine.Aero2 ||
                spellId == SpellsDefine.Dia)
                WhiteMageSpellHelper.RecordAero();
            else
                WhiteMageSpellHelper.RemoveRecordAero();
        }
    }
}
