using AEAssist.Define;
using AEAssist.Utilities.CombatMessages;
using ff14bot;

namespace AEAssist.AI.Monk
{
    public class MonkCombatMessageStrategy
    {
         public static void RegisterCombatMessages()
        {

            //Highest priority: Don't show anything if we're not in combat
            CombatMessageManager.RegisterMessageStrategy(
                new CombatMessageStrategy(100,
                                          "",
                                          () => !Core.Me.InCombat));

            // Second priority: Don't show anything if positional requirements are Nulled
             // CombatMessageManager.RegisterMessageStrategy(
             //     new CombatMessageStrategy(200,
             //                               "",
             //                               "/AEAssist;component/Resources/Images/General/ArrowDownHighlighted.png",
             //                               () => SettingMgr.GetSetting<MonkSettings>().HidePositionalToastsWithTn && MonkSpellHelper.InRaptorForm() || Core.Me.HasAura(AurasDefine.RiddleOfEarth)));

            //Third priority (tie): Bootshine
            // CombatMessageManager.RegisterMessageStrategy(
            //     new CombatMessageStrategy(300,
            //                               "Bootshine: Get behind Enemy",
            //                               () => Core.Me.HasAura(AurasDefine.OpoOpoForm) && Core.Me.HasAura(AurasDefine.LeadenFist)));

            // //Third priority (tie): TwinSnakes
            // CombatMessageManager.RegisterMessageStrategy(
            //     new CombatMessageStrategy(300,
            //                               "TwinSnakes: Side of Enemy",
            //                               () => Core.Me.HasAura(AurasDefine.RaptorForm) && !Core.Me.HasAura(AurasDefine.TwinSnakes, true, SettingMgr.GetSetting<MonkSettings>().TwinSnakesRefresh * 1100)));
            //
            // //Third priority (tie): TrueStrike
            // CombatMessageManager.RegisterMessageStrategy(
            //     new CombatMessageStrategy(300,
            //                               "TrueStrike: Get behind Enemy",
            //                               () => Core.Me.HasAura(AurasDefine.RaptorForm) && Core.Me.HasAura(AurasDefine.TwinSnakes, true, SettingMgr.GetSetting<MonkSettings>().TwinSnakesRefresh * 1000)));
            //
            //Third priority (tie): SnapPunch
            CombatMessageManager.RegisterMessageStrategy(
                new CombatMessageStrategy(200,
                                          "SnapPunch: Side of Enemy",
                                          () => MeleePosition.Intance.GetPriority() == MeleePosition.Priority.High && MeleePosition.Intance.GetRequiredPosition() == MeleePosition.Position.Side));
            //Third priority (tie): Demo
            CombatMessageManager.RegisterMessageStrategy(
                new CombatMessageStrategy(300,
                    "Demolish: Back of Enemy",
                    () => MeleePosition.Intance.GetPriority() == MeleePosition.Priority.High && MeleePosition.Intance.GetRequiredPosition() == MeleePosition.Position.Back));
            //
            // //Third priority (tie): DragonKick
            // CombatMessageManager.RegisterMessageStrategy(
            //     new CombatMessageStrategy(300,
            //                               "DragonKick: Side of Enemy",
            //                               () => Core.Me.HasAura(AurasDefine.OpoOpoForm) && !Core.Me.HasAura(AurasDefine.LeadenFist, true, SettingMgr.GetSetting<MonkSettings>().DragonKickRefresh * 1000)));
        }
    }
}