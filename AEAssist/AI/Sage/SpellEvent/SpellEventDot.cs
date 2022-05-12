using AEAssist.Define;

namespace AEAssist.AI.Sage.SpellEvent
{
    [SpellEvent(SpellsDefine.EukrasianDosis)]
    [SpellEvent(SpellsDefine.EukrasianDosisII)]
    [SpellEvent(SpellsDefine.EukrasianDosisIII)]
    public class SpellEventDot : ISpellEvent
    {
        public void Run(uint spellId)
        {
            if (spellId == SpellsDefine.EukrasianDosis || 
                spellId == SpellsDefine.EukrasianDosisII || 
                spellId == SpellsDefine.EukrasianDosisIII )
                SageSpellHelper.RecordEukrasianDosis();
            else
                SageSpellHelper.RemoveRecordEukrasianDosis();
        }
    }
}