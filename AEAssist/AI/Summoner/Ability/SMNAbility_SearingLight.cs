using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot.Managers;

namespace AEAssist.AI.Summoner.Ability
{
    public class SMNAbility_SearingLight : IAIHandler
    {
      
        bool CheckAethercharge(int timeleft)
        {
            if (SpellsDefine.SearingLight.IsUnlock() &&
                SpellsDefine.SearingLight.GetSpellEntity().Cooldown.TotalMilliseconds < timeleft)
                return true;
            return false;
        }
        public int Check(SpellEntity lastSpell)
        {
            if (!SpellsDefine.SearingLight.IsReady())
                return -1;
          
            if (AIRoot.Instance.CloseBurst)
            {
                return -2;
            }

            if (!AIRoot.Instance.Is2ndAbilityTime())
                return -3;
            
            var time = AIRoot.Instance.GetGCDDuration() * 0.5f;
           
            if (!CheckAethercharge((int)time))
                return -4;

            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            var spell = SpellsDefine.SearingLight;
            if (await spell.DoAbility()) return spell.GetSpellEntity();

            return null;
        }
    }
}