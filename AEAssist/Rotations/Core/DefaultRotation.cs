﻿using System.Threading.Tasks;
using AEAssist.Define;

namespace AEAssist.Rotations.Core
{
    public class DefaultRotation : IRotation
    {
        public void Init()
        {
        }

        public Task<bool> PreCombatBuff()
        {
            //   LogHelper.Debug("PreCombatBuff");
            return Task.FromResult(false);
        }

        public SpellEntity GetBaseGCDSpell()
        {
            return null;
        }
        
        public Task<bool> NoTarget()
        {
            return Task.FromResult(false);
        }

    }
}