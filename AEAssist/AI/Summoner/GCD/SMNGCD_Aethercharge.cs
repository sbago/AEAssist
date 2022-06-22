using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot.Managers;

namespace AEAssist.AI.Summoner.GCD
{
    public class SMNGCD_Aethercharge : IAIHandler
    {

        uint GetAethercharge()
        {
            if (SpellsDefine.SummonBahamut.IsUnlock())
                return SpellsDefine.SummonBahamut;

            return SpellsDefine.Aethercharge.IsUnlock() ? SpellsDefine.Aethercharge : 0;
        }
        public int Check(SpellEntity lastSpell)
        {
            var spell = GetAethercharge();

            if (!spell.IsReady())
                return -1;

            if (AIRoot.Instance.CloseBurst)
                return -2;

            if (SpellsDefine.SearingLight.CoolDownInGCDs(1))
                return -3;

            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            var spell = GetAethercharge().GetSpellEntity();

            if (await spell.DoGCD()) return spell;

            return null;
        }
    }
}