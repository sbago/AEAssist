using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot.Managers;

namespace AEAssist.AI.Sage.GCD
{
    public class SageBaseGCD : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            // don't cast dosis when moving, instead going to cast other spells.
            if (!MovementManager.IsMoving) return 0;
            LogHelper.Debug("Not casting Dosis, since we are moving.");
            return -10;
            // // prevent redundant casting
            // var battleData = AIRoot.GetBattleData<BattleData>();
            // if (battleData.lastGCDSpell == SpellsDefine.Dosis.GetSpellEntity() ||
            //     battleData.lastGCDSpell == SpellsDefine.DosisII.GetSpellEntity()||
            //     battleData.lastGCDSpell == SpellsDefine.DosisIII.GetSpellEntity()) {
            //     LogHelper.Info(battleData.lastGCDSpell.SpellData.LocalizedName);
            //     return -1;
            // }
        }

        public async Task<SpellEntity> Run()
        {
            var spell = SageSpellHelper.GetBaseGcd();
            if (spell == null) return null;
            var ret = await spell.DoGCD(); 
            return ret ? spell : null;
        }
    }
}