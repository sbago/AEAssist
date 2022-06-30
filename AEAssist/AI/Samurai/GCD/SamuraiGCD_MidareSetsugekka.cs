using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot.Managers;

namespace AEAssist.AI.Samurai.GCD
{
    public class SamuraiGCD_MidareSetsugekka : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            if (SamuraiSpellHelper.IsMidareSetsugekkaReady())
            {
                return 0;
            }
            return -1;
        }

        public async Task<SpellEntity> Run()
        {
            // AoERotations
            var spell = SpellsDefine.MidareSetsugekka.GetSpellEntity();
            if (spell == null)
                return null;
            var ret = await spell.DoGCD();
            if (ret)
                return spell;
            return null;
        }
    }
}