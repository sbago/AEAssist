using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot.Managers;

namespace AEAssist.AI.Summoner.GCD
{
    public class SMNGCD_Base : IAIHandler
    {
        static public uint getBase()
        {
            if (TargetHelper.CheckNeedUseAOE(25, 5) && SpellsDefine.TriDisaster.IsUnlock())
                return SpellsDefine.TriDisaster;

            if (SpellsDefine.Ruin3.IsUnlock())
                return SpellsDefine.Ruin3;
            if (SpellsDefine.Ruin2.IsUnlock())
                return SpellsDefine.Ruin2;
            return SpellsDefine.Ruin;
        }
        public int Check(SpellEntity lastSpell)
        {
            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            var spell = getBase().GetSpellEntity();
            if (spell == null) return null;
            var ret = await spell.DoGCD();
            return ret ? spell : null;
        }
    }
}