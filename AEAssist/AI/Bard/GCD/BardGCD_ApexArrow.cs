using System.Threading.Tasks;
using AEAssist;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist.AI
{
    public class BardGCD_ApexArrow : IAIHandler
    {
        public int Check(SpellData lastSpell)
        {
            if (!AEAssist.DataBinding.Instance.UseApex)
                return -1;
            if (ActionResourceManager.Bard.SoulVoice >= SettingMgr.GetSetting<BardSettings>().ApexArrowValue)
                return 1;

            if (ActionResourceManager.Bard.SoulVoice >= 80 &&
                (BardSpellHelper.HasBuffsCountInEnd() >= 1 || TargetHelper.CheckNeedUseAOE(ConstValue.BardAOETargetRange,
                    2, ConstValue.BardAOECount)))
            {
                return 2;
            }

            return -2;
        }

        public async Task<SpellData> Run()
        {
            var spell = SpellsDefine.ApexArrow;
            if (spell == null)
                return null;
            var ret = await SpellHelper.CastGCD(spell, Core.Me.CurrentTarget);
            if (ret)
                return spell;
            return null;
        }
    }
}