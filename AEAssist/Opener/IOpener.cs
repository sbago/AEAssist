// -----------------------------------
// 
// 模块说明：IOpener.cs
// 
// 创建人员：AE
// 创建日期：2022-04-14
// -----------------------------------

namespace AEAssist.Opener
{
    public interface IOpener
    {
        int StepCount { get; }
        int Check();
    }
}