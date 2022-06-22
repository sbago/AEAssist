using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot.Managers;

using ff14bot.Helpers;
using System.Windows.Media;
namespace AEAssist.AI.Summoner.Ability
{
    public class SMNAbility_Fester : IAIHandler
    {
        uint getFester()
        {
            if (TargetHelper.CheckNeedUseAOE(25, 5) && SpellsDefine.Painflare.IsUnlock())
                return SpellsDefine.Painflare;
            return SpellsDefine.Fester;
        }
        public int Check(SpellEntity lastSpell)
        {

            if (DebugSetting.debug)
            {
                Logging.Write(Colors.Red, this.GetType().Name);
            }

            if (!SpellsDefine.Fester.IsReady())
                return -1;
            if (ActionResourceManager.Summoner.Aetherflow <=0)
            {
                return -10;
            }
            if (lastSpell == SpellsDefine.Painflare.GetSpellEntity() || lastSpell == SpellsDefine.Fester.GetSpellEntity())
            {
                return -4;
            }
            if (AIRoot.Instance.CloseBurst)
            {
                if (SpellsDefine.EnergyDrain.IsReady())
                    return 0;

                if (SpellsDefine.EnergyDrain.CoolDownInGCDs(ActionResourceManager.Summoner.Aetherflow))
                    return 0;

                return -2;
            }

            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            var spell = getFester();
            if (await spell.DoAbility()) return spell.GetSpellEntity();

            return null;
        }
    }
}