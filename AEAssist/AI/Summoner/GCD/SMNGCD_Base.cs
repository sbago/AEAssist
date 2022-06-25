using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot.Managers;

namespace AEAssist.AI.Summoner.GCD
{
    public class SMNGCD_Base : IAIHandler
    {
        uint spell;
        static public uint GetSpell()
        {
            if (SMN_SpellHelper.CheckUseAOE())
                if (SpellsDefine.TriDisaster.IsUnlock())
                    return SpellsDefine.TriDisaster;
                else if (SpellsDefine.Outburst.IsUnlock())
                    return SpellsDefine.Outburst;

            if (SpellsDefine.Ruin3.IsUnlock())
                return SpellsDefine.Ruin3;
            if (SpellsDefine.Ruin2.IsUnlock())
                return SpellsDefine.Ruin2;
            return SpellsDefine.Ruin;
        }
        public int Check(SpellEntity lastSpell)
        {
            spell = GetSpell();
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