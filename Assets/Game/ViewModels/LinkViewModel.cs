using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public partial class LinkViewModel {

    PathManager myPath;
    float distance = -1.0f;

    MapNodeViewModel first;
    MapNodeViewModel second;

    public void Initialize(PathManager inPath, MapNodeViewModel first, MapNodeViewModel second)
    {
        myPath = inPath;
        first.AddNeighbor(this, second);
        second.AddNeighbor(this, first);
        
    }

    public float PathLength
    {
        get
        {
            if (distance > 0)
            {
                return distance;
            }

            float dist = 0;
            for (int i = 0; i < myPath.waypoints.Length - 1; ++i)
            {
                dist += (myPath.waypoints[i + 1].position - myPath.waypoints[i].position).magnitude;

            }

            distance = dist;

            return distance;

        }
    }

    public PathManager MyPath
    {
        get { return myPath; }
    }
}
