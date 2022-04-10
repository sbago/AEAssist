

using System.Collections.Generic;
using System.Threading.Tasks;

namespace AEAssist.AI
{
    public interface IAIPriorityQueue
    {
        List<IAIHandler> GCDQueue { get;}
        
        List<IAIHandler> AbilityQueue { get;}

        Task<bool> UsePotion();
    }
}