

using System.Collections.Generic;

namespace AEAssist.AI
{
    public interface IAIPriorityQueue
    {
        List<IAIHandler> GCDQueue { get;}
        
        List<IAIHandler> AbilityQueue { get;}
    }
}