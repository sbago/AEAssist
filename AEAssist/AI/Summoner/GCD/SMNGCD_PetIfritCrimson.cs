using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot.Managers;
using ff14bot;
namespace AEAssist.AI.Summoner.GCD
{
    public class SMNGCD_PetIfritCrimson : IAIHandler
    {
        static 
        uint spell;
        uint GetSpell()
        {
            if (Core.Me.HasAura(AurasDefine.IfritsFavor))
                return SpellsDefine.CrimsonCyclone;
            if (AIRoot.GetBattleData<BattleData>().lastGCDSpell !=null)
                if (AIRoot.GetBattleData<BattleData>().lastGCDSpell.Id == SpellsDefine.CrimsonCyclone)
                    return SpellsDefine.CrimsonStrike;
            return 0;
        }
        public int Check(SpellEntity lastSpell)
        {
            spell = GetSpell();
            if (spell == 0)
                return -3;
            if (!SMN_SpellHelper.Ifrit())
                return -4;
            if (!spell.IsReady())
                return -1;
            if (spell == SpellsDefine.CrimsonStrike && !Core.Me.CanAttackTargetInRange(Core.Me.CurrentTarget, 3))
                return -5;
            if (!DataBinding.Instance.Crimson)
            {
                return -6;
            }
            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            if (await spell.DoGCD()) return spell.GetSpellEntity();

            return null;
        }
    }
}