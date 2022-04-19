using System;

namespace AEAssist.Opener
{
    public class OpenerStepAttribute : Attribute
    {
        public int StepIndex;

        public OpenerStepAttribute(int stepIndex)
        {
            this.StepIndex = stepIndex;
        }
    }
}