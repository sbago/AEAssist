using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot.Managers;

using ff14bot.Helpers;
using System.Windows.Media;
namespace AEAssist.AI.Summoner.Ability
{
    public class SMNAbility_EnergyDrain : IAIHandler
    {
        uint spell;
        uint GetSpell()
        {
            if (SMN_SpellHelper.CheckUseAOE() && SpellsDefine.EnergySiphon.IsUnlock())
                return SpellsDefine.EnergySiphon;
            return SpellsDefine.EnergyDrain;
        }
        public int Check(SpellEntity lastSpell)
        {
            spell = GetSpell();
            if (!spell.IsReady())
                return -1;
            // 有豆子先把豆子打完
            if (ActionResourceManager.Summoner.Aetherflow != 0)
                return -10;

            

            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            if (await spell.DoAbility()) return spell.GetSpellEntity();

            return null;
        }
    }
}