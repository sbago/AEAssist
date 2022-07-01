﻿using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot.Managers;

using ff14bot.Helpers;
using System.Windows.Media;
namespace AEAssist.AI.Summoner.Ability
{
    public class SMNAbility_Fester : IAIHandler
    {
        uint spell;
        uint GetSpell()
        {
            if (SMN_SpellHelper.CheckUseAOE() && SpellsDefine.Painflare.IsUnlock())
                return SpellsDefine.Painflare;
            return SpellsDefine.Fester;
        }
        public int Check(SpellEntity lastSpell)
        {
            spell = GetSpell();
            if (!spell.IsReady())
                return -1;
            if (ActionResourceManager.Summoner.Aetherflow <=0)
            {
                return -10;
            }
            if (lastSpell == SpellsDefine.Painflare.GetSpellEntity() || lastSpell == SpellsDefine.Fester.GetSpellEntity())
            {
                return -4;
            }
            if (AIRoot.Instance.CloseBurst)
            {
                if (SpellsDefine.EnergyDrain.IsReady())
                    return 0;

                if (SpellsDefine.EnergyDrain.CoolDownInGCDs(ActionResourceManager.Summoner.Aetherflow))
                    return 0;

                return -2;
            }

            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            if (await spell.DoAbility()) return spell.GetSpellEntity();

            return null;
        }
    }
}