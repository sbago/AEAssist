using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Objects;

namespace AEAssist.AI
{
    public class BardAbility_Bloodletter : IAIHandler
    {
        public int Check(SpellData lastSpell)
        {
            if (lastSpell == SpellsDefine.Bloodletter)
                return -1;
            if (!SpellsDefine.Bloodletter.IsChargeReady())
                return -2;
            if (SpellsDefine.Bloodletter.Charges < 1)
                return -3;
            
            // 起手爆发期间, 失血箭尽量打进团辅

            if (BardSpellHelper.HasBuffsCount() >= BardSpellHelper.UnlockBuffsCount())
                return 1;

            if (BardSpellHelper.Prepare2BurstBuffs())
                return -4;
            
            return 0;
        }

        public async Task<SpellData> Run()
        {
            SpellData spellData = null;
            if (SpellsDefine.RainofDeath.IsChargeReady() && TargetHelper.CheckNeedUseAOE(25, 8, ConstValue.BardAOECount))
            {
                spellData = SpellsDefine.RainofDeath;
                if (await SpellHelper.CastAbility(spellData, Core.Me.CurrentTarget))
                {
                    return spellData;
                }
            }

            spellData = SpellsDefine.Bloodletter;
            if (await SpellHelper.CastAbility(spellData, Core.Me.CurrentTarget))
            {
                return spellData;
            }

            return null;
        }
    }
}