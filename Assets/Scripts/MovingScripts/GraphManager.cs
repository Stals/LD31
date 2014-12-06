using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleDeixtra;

class GraphManager
{

    #region SingletonPart

    static GraphManager graphManager = null;

    public static GraphManager Instance
    {
        get
        {
            if (graphManager == null)
            {
                graphManager = new GraphManager();
            }

            return graphManager;
        }
    }

    #endregion

    List<MapNodeViewModel> allMapNodes = new List<MapNodeViewModel>();
    List<LinkViewModel> allLinks = new List<LinkViewModel>();

    public void AddMapNode(MapNodeViewModel newNode)
    {
        newNode.MyIndex = allMapNodes.Count;
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
