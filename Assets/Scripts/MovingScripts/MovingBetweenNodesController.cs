using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UniRx;

public class MovingBetweenNodesController {

    float totalLength = 0;
    float nowLength = 0;
    public bool reachedEnd = false;

    int nowLinkId;
    float nowLeftLength;

    List<float> linksLengths = new List<float>();
    List<LinkViewModel> links;
    List<bool> direction = new List<bool>();    

    public MovingBetweenNodesController(List<LinkViewModel> inputLinks, MapNodeViewModel start)
    {
        

        links = inputLinks;
        MapNodeViewModel nowStart = start;
        
        float length = 0f;

        for (int i = 0;  i < inputLinks.Count; ++i)
        {
            float nowL = inputLinks[i].PathLength;
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

        if (totalLength == 0f)
        {
            reachedEnd = true;
        }

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

    void Update()
    {
        if (linksLengths.Count == 0)
        {
            return;
        }


        float toGo = nowLength;
        int i = 0;
        while ((i < linksLengths.Count) && (toGo > linksLengths[i]))
        {
            toGo -= linksLengths[i];
            i++;
        }
        
        if (i == linksLengths.Count)
        {
            nowLinkId = i - 1;
            nowLeftLength = linksLengths[i];
        }
        else
        {
            nowLinkId = i;
            nowLeftLength = toGo;
        }

       
    }

    Vector3 NowPosition
    {
        get
        {
            return PositionInGivenLink(nowLeftLength / linksLengths[nowLinkId], nowLinkId);
        }
    }

    public void moveMe(UnitViewModel objectToMove, float speed)
    {
        nowLength += speed;

        Update();

        if (nowLength >= totalLength)
        {
            reachedEnd = true;
        }

        objectToMove.Position = NowPosition;

    }

    public void addWalkedLength(float addedLength)
    {
        nowLength += addedLength;
    }

    public List<LinkViewModel> Links
    {
        get { return links; }
    }

    public float TotalLength
    {
        get
        {
            return totalLength;
        }
    }
    
    public void PushLinkToStart(LinkViewModel link)
    {
        bool newDirection = false;

        bool allOk = false;

        if (direction[0])
        {
            if (link.node2 == links[0].node1)
            {
                newDirection = true;
                allOk = true;
            }
            else if (link.node1 == links[0].node1)
            {
                newDirection = false;
                allOk = true;
            }
        } else
        {
            if (link.node2 == links[0].node2)
            {
                newDirection = true;
                allOk = true;
            }
            else if (link.node1 == links[0].node2)
            {
                newDirection = false;
                allOk = true;
            }
        }

        if (!allOk)
        {
            return;
        }

        links.Insert(0, link);
        direction.Insert(0, newDirection);
        totalLength += link.PathLength;
                
    }

    public int NowIndex
    {
        get
        {
            Update();
            return nowLinkId;
        }

    }

    public LinkViewModel NowLink
    {
        get
        {
            Update();
            return links[nowLinkId];
        }

    }

    public float NowLength
    {
        get
        {
            Update();
            return nowLength;
        }

    }

    public MapNodeViewModel NowStartNode
    {
        get
        {
            Update();
            if (direction[nowLinkId])
            {
                return links[nowLinkId].node1;
            }
            else
            {
                return links[nowLinkId].node2;
            }
        }

    }

}
