using System;
using System.Linq;
using System.Windows.Media;
using AEAssist.Define;
using AEAssist.Define.DataStruct;
using AEAssist.Helper;
using Buddy.Coroutines;
using ff14bot;
using ff14bot.Helpers;
using ff14bot.Managers;
using ff14bot.Objects;
using ff14bot.RemoteWindows;

namespace AEAssist.AI.Summoner
{
    public static class SMN_SpellHelper
    {
        public static SpellEntity GetBaseGcd()
        {
            return GetRuin();
        }
        public static SpellEntity GetRuin()
        {
            return SpellsDefine.Ruin.GetSpellEntity();
            //if (!SpellsDefine.Dosis.IsUnlock())
            //{
            //    LogHelper.Debug("Dosis not unlocked. skipping.");
            //    return null;
            //}

            //if (!SpellsDefine.DosisII.IsUnlock())
            //{
            //    if (!ActionManager.HasSpell(SpellsDefine.Dosis))
            //    {
            //        LogHelper.Debug("Dosis not found. skipping.");
            //        return null;
            //    }

            //    LogHelper.Debug("Using Dosis. ");
            //    return SpellsDefine.Dosis.GetSpellEntity();
            //}

            //if (!SpellsDefine.DosisIII.IsUnlock())
            //{
            //    if (!ActionManager.HasSpell(SpellsDefine.DosisII))
            //    {
            //        LogHelper.Debug("DosisII not found. skipping.");
            //        return null;
            //    }

            //    LogHelper.Debug("Using DosisII. ");
            //    return SpellsDefine.DosisII.GetSpellEntity();
            //}

            //if (ActionManager.HasSpell(SpellsDefine.DosisIII)) return SpellsDefine.DosisIII.GetSpellEntity();
            //LogHelper.Debug("DosisIII not found: unlocked?");
            //return null;
        }
    }
}