using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Objects;

namespace AEAssist.AI
{
    public class BardAbility_EmpyrealArrow : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            if (!SpellsDefine.EmpyrealArrow.IsUnlock())
                return -1;

            if (SettingMgr.GetSetting<BardSettings>().EarlyEmpyrealArrow)
            {
                if (SpellsDefine.EmpyrealArrow.Cooldown.TotalMilliseconds > 300)
                    return -2;
            }
            else
            {
                if (SpellsDefine.EmpyrealArrow.Cooldown.TotalMilliseconds > 50)
                    return -3; 
            }

   
            
            var ret = BardSpellHelper.PrepareSwitchSong();
            if (ret > 0)
            {
                return -4;
            }

            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            var spell = SpellsDefine.EmpyrealArrow;
            if (spell == null)
                return null;
            var ret = await spell.DoAbility();
            if (ret)
                return spell;
            return null;
        }
    }
}