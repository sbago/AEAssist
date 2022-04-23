// -----------------------------------
// 
// 模块说明：IOpener.cs
// 
// 创建人员：AE
// 创建日期：2022-04-14
// -----------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using AEAssist.AI;
using ff14bot.Objects;

namespace AEAssist.Opener
{
    public interface IOpener
    {
        int Check();
        int StepCount { get; }
    }
}