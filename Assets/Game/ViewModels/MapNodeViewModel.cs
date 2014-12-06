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



    public void AddNeighbor(LinkViewModel newLink, MapNodeViewModel mapViewModel)
    {
        NeighborInfo newInfo = new NeighborInfo();

        newInfo.link = newLink;
        newInfo.

    }

    #region IWeightGraphRealization
    int IWeightGraphElement.MyIndex
    {
        get
        {
            throw new NotImplementedException();
        }
        set
        {
            throw new NotImplementedException();
        }
    }

    int IWeightGraphElement.NumberOfNeighbors
    {
        get { throw new NotImplementedException(); }
    }

    IWeightGraphElement IWeightGraphElement.MyNeighbor(int ind)
    {
        throw new NotImplementedException();
    }

    float IWeightGraphElement.MyNeighborDistance(int ind)
    {
        throw new NotImplementedException();
    }

    #endregion
}
