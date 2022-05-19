using AEAssist.AI;
using AEAssist.Define;
using AEAssist.Helper;

namespace AEAssist.View.Hotkey.BuiltinHotkeys
{
    public class EnAvant : IBuiltinHotkey
    {
        public void OnHotkeyDown()
        {
            AIRoot.GetBattleData<BattleData>().NextAbilitySpellId = SpellsDefine.EnAvant.GetSpellEntity();
        }

        public string GetDisplayString()
        {
            return Language.Instance.Combox_Hotkey_EnAvant;
        }
    }
}