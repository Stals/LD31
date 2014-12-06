using System.Collections.Generic;

namespace SimpleDeixtra
{
    public interface IWeightGraphElement
    {

        int MyIndex { get; set; }

        int NumberOfNeighbors { get; }
        IWeightGraphElement MyNeighbor(int ind);
        float MyNeighborDistance(int ind);
    }
}