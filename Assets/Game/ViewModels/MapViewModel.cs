using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public partial class MapViewModel {

    List<MapNodeViewModel> allMapNodes = new List<MapNodeViewModel>();
    List<LinkViewModel> allLinks = new List<LinkViewModel>();

    public void AddMapNode(MapNodeViewModel newNode)
    {
        allMapNodes.Add(newNode);
    }

    public void AddLink(LinkViewModel newLinkViewModel)
    {
        allLinks.Add(newLinkViewModel);
    }

    public List<MapNodeViewModel> MapNodes
    {
        get
        {
            return allMapNodes;
        }
    }

    public List<LinkViewModel> MapLinks
    {
        get
        {
            return allLinks;
        }
    }
}
