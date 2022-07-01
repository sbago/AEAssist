﻿using System;
using System.Linq;
using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using Buddy.Coroutines;
using ff14bot;
using ff14bot.Helpers;
using ff14bot.Managers;
using ff14bot.Objects;
namespace AEAssist.AI.WhiteMage.Ability
{
    public class WhiteMageAbilityLucidDreaming : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            if (!SpellsDefine.LucidDreaming.IsReady() || Core.Me.HasAura(AurasDefine.LucidDreaming)) return -1;
            if (Core.Me.CurrentManaPercent >= SettingMgr.GetSetting<WhiteMageSettings>().LucidDreamingTrigger) return -1;
            if (!SettingMgr.GetSetting<WhiteMageSettings>().LucidDreamingToggle) return -1;
            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            var spell = SpellsDefine.LucidDreaming.GetSpellEntity();
            if (spell == null) return null;
            var ret = await spell.DoAbility();
            return ret ? spell : null;
        }
    }
}
