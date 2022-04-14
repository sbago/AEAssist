// -----------------------------------
// 
// 模块说明：OpenerAttribute.cs
// 
// 创建人员：AE
// 创建日期：2022-04-14
// -----------------------------------

using System;
using ff14bot.Enums;

namespace AEAssist.Opener
{
    public class OpenerAttribute : Attribute
    {
        public ClassJobType ClassJobType;
        public int Level;

        public OpenerAttribute(ClassJobType classJobType,int level)
        {
            this.ClassJobType = classJobType;
            this.Level = level;
        }
    }
}