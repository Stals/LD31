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

    public void Initialize(PathManager myPath, MapNodeViewModel first, MapNodeViewModel second)
    {
        first.AddNeighbor(this, second);
        second.AddNeighbor(this, first);
    }

    public float GetPathLength
    {
        get
        {
            if (distance > 0)
            {
                return distance;
            }

            float dist = 0;
            for (int i = 1; i < myPath.waypoints.Length; ++i)
            {
                dist += (myPath.waypoints[i].position - myPath.waypoints[i - 1].position).magnitude;

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
