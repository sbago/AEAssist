using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Objects;

namespace AEAssist.AI
{
    public class BardAbility_MaxChargeBloodletter : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            if (lastSpell == SpellsDefine.Bloodletter.GetSpellEntity())
                return -1;
            if (!SpellsDefine.Bloodletter.IsReady())
                return -2;
            if (SpellsDefine.Bloodletter.IsMaxChargeReady())
                return 0;
            return -3;
        }

        public async Task<SpellEntity> Run()
        {
            SpellEntity SpellEntity = SpellsDefine.Bloodletter.GetSpellEntity();
            if (SpellsDefine.RainofDeath.IsReady() && TargetHelper.CheckNeedUseAOE(25, 8, ConstValue.BardAOECount))
            {
                SpellEntity = SpellsDefine.RainofDeath.GetSpellEntity();
            }
            
            if (await SpellEntity.DoAbility()) return SpellEntity;

            return null;
        }
    }
}