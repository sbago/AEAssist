using System.Threading.Tasks;
using AEAssist.Define;
using ff14bot;
using AEAssist.Helper;
using ff14bot.Managers;

namespace AEAssist.AI.GunBreaker.GCD
{
    public class GunBreakerGCD_SecondaryCombo : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            if (ActionResourceManager.Gunbreaker.SecondaryComboStage > 0)
            {
                if (SpellsDefine.SonicBreak.IsReady()|| (SpellsDefine.DoubleDown.IsReady() && (ActionResourceManager.Gunbreaker.Cartridge>1)))
                    return -10;
                return 100;
            }
            if (!DataBinding.Instance.Burst)
                return -100;

            if (ActionResourceManager.Gunbreaker.Cartridge == 0)
                return -1;

            if (!SpellsDefine.GnashingFang.GetSpellEntity().SpellData.IsReady())
                return -2;

            if (SpellsDefine.NoMercy.GetSpellEntity().SpellData.Charges < 0.5)
                return 1;

            if (SpellsDefine.NoMercy.GetSpellEntity().SpellData.CoolDownInGCDs(4))
                return -5;
            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            var spell = GunBreakerSpellHelper.SecondaryCombo();
            if (await spell.DoGCD())
                return spell;
            return null;
        }
    }
}