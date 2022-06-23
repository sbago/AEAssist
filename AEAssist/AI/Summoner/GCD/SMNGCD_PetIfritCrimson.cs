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
            if (ActionManager.LastSpell.Id==SpellsDefine.CrimsonCyclone &&Core.Me.CurrentTarget.Distance(Core.Me) <= 3)
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
            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            if (await spell.DoGCD()) return spell.GetSpellEntity();

            return null;
        }
    }
}