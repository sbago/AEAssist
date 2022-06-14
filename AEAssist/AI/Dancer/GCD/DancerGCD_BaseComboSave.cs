using System.Threading.Tasks;
using AEAssist.AI.Sage;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;

namespace AEAssist.AI.Dancer.GCD
{
    public class DancerGCD_BaseComboSave : IAIHandler
    {
        public int Check(SpellEntity lastGCD)
        {
            if (ActionManager.ComboTimeLeft > 0 &&
                ActionManager.ComboTimeLeft < 3.5f)
            {
                if (ActionManager.LastSpellId == SpellsDefine.Windmill)
                {
                    if (TargetHelper.CheckNeedUseAOETest(Core.Me.CurrentTarget, 5, 5, 3))
                    {
                        return 1;
                    }
                }
                if (ActionManager.LastSpellId == SpellsDefine.Cascade)
                {
                    if (!TargetHelper.CheckNeedUseAOETest(Core.Me.CurrentTarget, 5, 5, 3))
                    {
                        return 1;
                    }
                }
            }

            return -4;
        }

        public async Task<SpellEntity> Run()
        {
            var spell = SpellsDefine.Fountain.GetSpellEntity();
            if (ActionManager.LastSpellId == SpellsDefine.Windmill)
            {
                spell = SpellsDefine.Bladeshower.GetSpellEntity();
            }
            if (spell == null)
                return null;
            var ret = await spell.DoGCD();
            if (ret)
                return spell;
            return null;
        }
    }
}