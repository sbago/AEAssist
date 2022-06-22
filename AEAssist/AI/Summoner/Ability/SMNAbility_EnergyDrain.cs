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
        uint getEnergyDrain()
        {
            if (TargetHelper.CheckNeedUseAOE(25, 5) && SpellsDefine.EnergySiphon.IsUnlock())
                return SpellsDefine.EnergySiphon;
            return SpellsDefine.EnergyDrain;
        }
        public int Check(SpellEntity lastSpell)
        {
            if (DebugSetting.debug)
            {
                Logging.Write(Colors.Red, this.GetType().Name);
            }

            if (!SpellsDefine.EnergyDrain.IsReady())
                return -1;
            // 有豆子先把豆子打完
            if (ActionResourceManager.Summoner.Aetherflow != 0)
                return -10;

            

            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            var spell = getEnergyDrain();
            if (await spell.DoAbility()) return spell.GetSpellEntity();

            return null;
        }
    }
}