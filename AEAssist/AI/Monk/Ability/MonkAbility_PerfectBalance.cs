using System;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist.AI.Monk.Ability
{
    public class MonkAbility_PerfectBalance : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            if (!SpellsDefine.PerfectBalance.IsUnlock())
            {
                return -10;
            }

            if (!SpellsDefine.PerfectBalance.IsReady())
            {
                return -1;
            }

            if (SpellsDefine.PerfectBalance.RecentlyUsed() || Core.Me.HasAura(AurasDefine.PerfectBalance))
            {
                return -2;
            }

            if (ActionResourceManager.Monk.BlitzTimer != TimeSpan.Zero)
            {
                return -5;
            }

            if (Core.Me.HasAura(AurasDefine.FormlessFist) || MonkSpellHelper.LastSpellWasNadi())
            {
                return -4;
            }
            
            if (!MonkSpellHelper.InRaptorForm())
            {
                return -3;
            }



            var target = Core.Me.CurrentTarget as Character;

            if (!SpellsDefine.ElixirField.IsUnlock())
            {
                // dmg buff
                if (Core.Me.HasMyAuraWithTimeleft(AurasDefine.DisciplinedFist, 9000))
                {
                    // using dot
                    if (MonkSpellHelper.UsingDot())
                    {
                        // dot timeleft safe
                        if (target.HasMyAuraWithTimeleft(AurasDefine.Demolish, 9000))
                        {
                            AIRoot.GetBattleData<MonkBattleData>().CurrentMonkNadiCombo = MonkNadiCombo.Lunar;
                            return 1;
                        }
                    }
                    // not using dot
                    else
                    {
                        AIRoot.GetBattleData<MonkBattleData>().CurrentMonkNadiCombo = MonkNadiCombo.Lunar;
                        return 1;
                    }
                }

                return -4;
            }

            //even window
            if (Core.Me.HasAura(AurasDefine.Brotherhood) || SpellsDefine.Brotherhood.CoolDownInGCDs(10) ||
                SpellsDefine.Brotherhood.RecentlyUsed())
            {
                //pre rof ROF+BH 1&3
                if (SpellsDefine.RiddleofFire.CoolDownInGCDs(1) && !Core.Me.HasAura(AurasDefine.RiddleOfFire))
                {
                    if (target.HasMyAuraWithTimeleft(AurasDefine.Demolish, 15000) &&
                        Core.Me.HasMyAuraWithTimeleft(AurasDefine.DisciplinedFist, 10000))
                    {
                        AIRoot.GetBattleData<MonkBattleData>().CurrentMonkNadiCombo = MonkNadiCombo.Lunar;
                        return 3;
                    }

                    AIRoot.GetBattleData<MonkBattleData>().CurrentMonkNadiCombo = MonkNadiCombo.Solar;
                    return 1;
                }

                //pre rof ROF+BH 2
                if (SpellsDefine.RiddleofFire.CoolDownInGCDs(4) && !Core.Me.HasAura(AurasDefine.RiddleOfFire))
                {
                    if (target.HasMyAuraWithTimeleft(AurasDefine.Demolish, 15000))
                    {
                        AIRoot.GetBattleData<MonkBattleData>().CurrentMonkNadiCombo = MonkNadiCombo.Solar;
                        return 2;
                    }
                }

                //during rof 
                if (Core.Me.HasAura(AurasDefine.RiddleOfFire) || SpellsDefine.RiddleofFire.RecentlyUsed())
                {
                    //ROF+BH 2
                    if (ActionResourceManager.Monk.ActiveNadi == ActionResourceManager.Monk.Nadi.Solar &&
                        Core.Me.HasMyAuraWithTimeleft(AurasDefine.DisciplinedFist, 10000) &&
                        target.HasMyAuraWithTimeleft(AurasDefine.Demolish, 15000)
                       )
                    {
                        AIRoot.GetBattleData<MonkBattleData>().CurrentMonkNadiCombo = MonkNadiCombo.Lunar;
                        return 1;
                    }
                    else
                    {
                        //ROF+BH 1&3
                        if (ActionResourceManager.Monk.ActiveNadi == ActionResourceManager.Monk.Nadi.Solar ||
                            ActionResourceManager.Monk.ActiveNadi == ActionResourceManager.Monk.Nadi.Both)
                        {
                            AIRoot.GetBattleData<MonkBattleData>().CurrentMonkNadiCombo = MonkNadiCombo.Lunar;
                        }
                        else if (ActionResourceManager.Monk.ActiveNadi == ActionResourceManager.Monk.Nadi.Lunar)
                        {
                            AIRoot.GetBattleData<MonkBattleData>().CurrentMonkNadiCombo = MonkNadiCombo.Solar;
                        }

                        return 1;
                    }
                }
            }
            //odd window
            else
            {   
                //Pre PB
                if (SpellsDefine.RiddleofFire.CoolDownInGCDs(2) && !Core.Me.HasAura(AurasDefine.RiddleOfFire))
                {
                    if (target.HasMyAuraWithTimeleft(AurasDefine.Demolish, 15000) &&
                        Core.Me.HasMyAuraWithTimeleft(AurasDefine.DisciplinedFist, 10000))
                    {
                        AIRoot.GetBattleData<MonkBattleData>().CurrentMonkNadiCombo = MonkNadiCombo.Lunar;
                        return 4;
                    }
                }

                if (Core.Me.HasMyAura(AurasDefine.RiddleOfFire))
                {
                    if (target.HasMyAuraWithTimeleft(AurasDefine.Demolish, 15000) &&
                        Core.Me.HasMyAuraWithTimeleft(AurasDefine.DisciplinedFist, 10000))
                    {
                        AIRoot.GetBattleData<MonkBattleData>().CurrentMonkNadiCombo = MonkNadiCombo.Lunar;
                        return 5;
                    }
                }
            }


            return -4;
        }


        public async Task<SpellEntity> Run()
        {
            var spell = SpellsDefine.PerfectBalance.GetSpellEntity();
            if (spell == null)
                return null;
            var ret = await spell.DoAbility();
            if (ret)
                return spell;
            return null;
        }
    }
}