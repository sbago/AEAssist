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
            var target = Core.Me.CurrentTarget as Character;

            if (!SpellsDefine.ElixirField.IsUnlock())
            {
                if (MonkSpellHelper.InRaptorForm())
                {
                    // dmg buff
                    if (Core.Me.HasMyAuraWithTimeleft(AurasDefine.DisciplinedFist, 7000))
                    {
                        // using dot
                        if (MonkSpellHelper.UsingDot())
                        {
                            // dot timeleft safe
                            if (target.HasMyAuraWithTimeleft(AurasDefine.Demolish, 9000))
                            {
                                return 1;
                            }
                        }
                        // not using dot
                        else
                        {
                            return 1;

                        }
                    }
                }
            }
            
            //pre rof 
            if (SpellsDefine.RiddleofFire.CoolDownInGCDs(2) && !Core.Me.HasAura(AurasDefine.RiddleOfFire))
            {
                //even rof + bh
                if (Core.Me.HasAura(AurasDefine.Brotherhood) || SpellsDefine.Brotherhood.CoolDownInGCDs(10) ||
                    SpellsDefine.Brotherhood.RecentlyUsed())
                {
                    if (MonkSpellHelper.InRaptorForm())
                    {
                        if (target.HasMyAuraWithTimeleft(AurasDefine.Demolish, 15000))
                        {
                            return 2;
                        }
                    }
                }
                //odd
                // if (MonkSpellHelper.InRaptorForm())
                // {
                //     if (Core.Me.HasMyAuraWithTimeleft(AurasDefine.DisciplinedFist, 7000) &&
                //         target.HasMyAuraWithTimeleft(AurasDefine.Demolish, 9000))
                //     {
                //         return 1;
                //     }
                // }
            }
            //during rof 
            if (Core.Me.HasAura(AurasDefine.RiddleOfFire) || SpellsDefine.RiddleofFire.RecentlyUsed())
            {
                if (MonkSpellHelper.InRaptorForm())
                {
                    //没有演武
                    //没有必杀技
                    //上一个技能不是必杀技 => 不会有演武
                    if (!Core.Me.HasAura(AurasDefine.FormlessFist) && !MonkSpellHelper.LastSpellWasNadi() && ActionResourceManager.Monk.BlitzTimer == TimeSpan.Zero)
                    {
                        //even
                        if (Core.Me.HasAura(AurasDefine.Brotherhood) || SpellsDefine.Brotherhood.RecentlyUsed())
                        {
                            return 1;
                        }
                        //odd
                        if (Core.Me.HasMyAuraWithTimeleft(AurasDefine.DisciplinedFist, 7000) &&
                            target.HasMyAuraWithTimeleft(AurasDefine.Demolish, 9000))
                        {
                            return 1;
                        }
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