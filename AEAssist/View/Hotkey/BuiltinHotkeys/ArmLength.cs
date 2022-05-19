using AEAssist.AI;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot.Managers;

namespace AEAssist.View.Hotkey.BuiltinHotkeys
{
    public class ArmLength : IBuiltinHotkey
    {
        public void OnHotkeyDown()
        {
            if (ActionManager.HasSpell(SpellsDefine.ArmsLength))
                AIRoot.GetBattleData<BattleData>().NextAbilitySpellId =
                    SpellsDefine.ArmsLength.GetSpellEntity();
            else
                AIRoot.GetBattleData<BattleData>().NextAbilitySpellId =
                    SpellsDefine.Surecast.GetSpellEntity();
        }

        public string GetDisplayString()
        {
            return Language.Instance.Combox_Hotkey_ArmLength;
        }
    }
}