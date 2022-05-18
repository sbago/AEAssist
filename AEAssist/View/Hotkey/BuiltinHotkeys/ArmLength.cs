using AEAssist.AI;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot.Managers;

namespace AEAssist.View.Hotkey.BuiltinHotkeys
{
    public class ArmLength : IBuiltinHotkey
    {
        public void Run()
        {
            AIRoot.GetBattleData<BattleData>().NextAbilitySpellId =
                SpellsDefine.ArmsLength.GetSpellEntity();
        }
    }
}