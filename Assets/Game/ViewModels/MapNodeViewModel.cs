using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using SimpleDeixtra;



public partial class MapNodeViewModel: IWeightGraphElement  {

    struct NeighborInfo
    {
        public LinkViewModel link;
        public MapNodeViewModel neighbor;
        public float distance;
    }


    List<NeighborInfo> allNeighbors = new List<NeighborInfo>();

    int indexInMap;


    public void AddNeighbor(LinkViewModel newLink, MapNodeViewModel mapViewModel)
    {
        NeighborInfo newInfo = new NeighborInfo();

        newInfo.link = newLink;
        newInfo.neighbor = mapViewModel;
        newInfo.distance = newLink.GetPathLength;


        allNeighbors.Add(newInfo);
    }

    #region IWeightGraphRealization

    public int MyIndex
    {
        get
        {
            return indexInMap;
        }
        set
        {
            indexInMap = value;
        }
    }

    public int NumberOfNeighbors
    {
        get { return allNeighbors.Count; }
    }

    public IWeightGraphElement MyNeighbor(int ind)
    {
        return allNeighbors[ind].neighbor;
    }

    public float MyNeighborDistance(int ind)
    {
        return allNeighbors[ind].distance;
    }

    #endregion
}
