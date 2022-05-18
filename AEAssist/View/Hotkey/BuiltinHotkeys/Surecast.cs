using AEAssist.AI;
using AEAssist.Define;
using AEAssist.Helper;

namespace AEAssist.View.Hotkey.BuiltinHotkeys
{
    public class Surecast : IBuiltinHotkey
    {
        public void Run()
        {
            AIRoot.GetBattleData<BattleData>().NextAbilitySpellId =
                SpellsDefine.Surecast.GetSpellEntity();
        }
    }
}