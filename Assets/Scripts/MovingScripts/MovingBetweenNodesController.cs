using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UniRx;

public class MovingBetweenNodesController {

    float totalLength = 0;
    float nowLength = 0;
    bool reachedEnd = false;

    List<float> linksLengths = new List<float>();
    List<LinkViewModel> links;
    List<bool> direction = new List<bool>();
    

    MovingBetweenNodesController(List<LinkViewModel> inputLinks, MapNodeViewModel start)
    {
        float length = 0f;

        links = inputLinks;
        MapNodeViewModel nowStart = start;

        for (int i = 0;  i < inputLinks.Count; ++i)
        {
            float nowL = inputLinks[i].GetPathLength;
            length += nowL;
            linksLengths.Add(nowL);
            if (nowStart == inputLinks[i].node1)
            {
                direction.Add(true);
                nowStart = inputLinks[i].node2;
            }
            else
            {
                direction.Add(false);
                nowStart = inputLinks[i].node1;
            }
        }        

        totalLength = length;

        nowLength = 0f;
    }

    Vector3 PositionInGivenLink(float t, int i)
    {
        if (direction[i])
        {
            return links[i].MyPath.GetPoint(t);
        }
        else
        {
            return links[i].MyPath.GetPoint(1.0f - t);
        }
    }

    Vector3 NowPosition
    {
        get
        {
            float toGo = nowLength;
            int i = 0;
            while ((toGo > linksLengths[i])&&(i < linksLengths.Count))
            {
                toGo -= linksLengths[i];
                i++;
            }

            if (i == linksLengths.Count)
            {
                return PositionInGivenLink(1.0f, i - 1);
            }

            return PositionInGivenLink(toGo / linksLengths[i], i - 1);
        }
    }

    void moveMe(UnitView objectToMove, float speed)
    {
        nowLength += speed;
        
        if (nowLength >= totalLength)
        {
            // paste here event on end path
        }

        objectToMove.transform.position = NowPosition;

    }

}
