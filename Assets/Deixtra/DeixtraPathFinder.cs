using System.Collections;
using System.Collections.Generic;

namespace SimpleDeixtra
{
    public class DeixtraPathFinder
    {

        List<IWeightGraphElement> graph;
        float[] currentWeights = new float[0];
        bool[] currentChecked = new bool[0];

        public void LoadGraph(IEnumerable<IWeightGraphElement> newGraph)
        {
            graph = new List<IWeightGraphElement>();
            foreach (IWeightGraphElement graphElem in newGraph)
            {
                graph.Add(graphElem);
            }

            currentWeights = new float[graph.Count];
            currentChecked = new bool[graph.Count];
        }

        void Colorify(IWeightGraphElement from)
        {
            float currentValue = currentWeights[from.MyIndex];
            currentChecked[from.MyIndex] = true;

            for (int i = 0; i < from.NumberOfNeighbors; ++i)
            {
                float newDistance = currentValue + from.MyNeighborDistance(i);
                int currentNeighborIndex = from.MyNeighbor(i).MyIndex;

                if (!from.MyNeighbor(i).IActive)
                {
                    currentChecked[currentNeighborIndex] = true;
                    continue;
                }

                if (newDistance < currentWeights[currentNeighborIndex])
                {
                    currentWeights[currentNeighborIndex] = newDistance;
                    currentChecked[currentNeighborIndex] = false;
                }

            }

            for (int i = 0; i < from.NumberOfNeighbors; ++i)
            {
                int currentNeighborIndex = from.MyNeighbor(i).MyIndex;
                if (!currentChecked[currentNeighborIndex])
                {
                    Colorify(from.MyNeighbor(i));
                }
            }
        }

        void clearValues()
        {
            for (int i = 0; i < currentWeights.Length; ++i)
            {
                currentWeights[i] = float.MaxValue;
            }

            for (int i = 0; i < currentChecked.Length; ++i)
            {
                currentChecked[i] = false;
            }
        }

        List<int> getBackPath(IWeightGraphElement to)
        {
            List<int> result = new List<int>();


            float nowWeight = currentWeights[to.MyIndex];

            if (nowWeight == float.MaxValue)
            {
                return result;
            }

            IWeightGraphElement nowElem = to;
            int safeCounter = 0;

            while ((nowWeight > 0f)&&(safeCounter < 2000))
            {
                safeCounter++;
                IWeightGraphElement bestNeighbor = nowElem;
                float bestValue = currentWeights[nowElem.MyIndex] * 2f;
                for (int i = 0; i < nowElem.NumberOfNeighbors; ++i)
                {
                    float nowValue = currentWeights[nowElem.MyNeighbor(i).MyIndex] + nowElem.MyNeighborDistance(i);
                    if (nowValue < bestValue)
                    {
                        bestValue = nowValue;
                        bestNeighbor = nowElem.MyNeighbor(i);
                    }
                }

                for (int i = 0; i < bestNeighbor.NumberOfNeighbors; ++i)
                {
                    if (bestNeighbor.MyNeighbor(i) == nowElem)
                    {
                        result.Add(i);
                    }
                }

                nowElem = bestNeighbor;
            }
            
            result.Reverse();

            return result;
        }
 
        /// <summary>
        /// find path between elements 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns>null if path not found, zero size array if from == to</returns>
        public IEnumerable<int> getPath(IWeightGraphElement from, IWeightGraphElement to)
        {
            if (from == to)
            {                
                return new List<int>();                
            }

            clearValues();

            currentWeights[from.MyIndex] = 0f;
            Colorify(from);

            List<int> result = getBackPath(to);

            if (result.Count == 0)
            {
                return null;
            }

            return result;
        }


    }

}