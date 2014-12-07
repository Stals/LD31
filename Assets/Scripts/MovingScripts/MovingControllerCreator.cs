using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SimpleDeixtra;
using System.Linq;

public class MovingControllerCreator {

    #region SingletonPart

    static MovingControllerCreator movingControllerCreator = null;

    public static MovingControllerCreator Instance
    {
        get
        {
            if (movingControllerCreator == null)
            {
                movingControllerCreator = new MovingControllerCreator(GraphManager.Instance.MapNodes);
            }

            return movingControllerCreator;
        }
    }

    #endregion

    DeixtraPathFinder pathFinder = new DeixtraPathFinder();

    public MovingControllerCreator(List<MapNodeViewModel> nodes)
    {
        List<IWeightGraphElement> list = nodes.Cast<IWeightGraphElement>().ToList();

        pathFinder.LoadGraph(list);
    }

    public MovingBetweenNodesController CreatePath(MapNodeViewModel from, MapNodeViewModel to)
    {
        IEnumerable<int> newPath = pathFinder.getPath(from, to);

        List<LinkViewModel> links = new List<LinkViewModel>();
        MapNodeViewModel now = from;

        foreach (int i in newPath)
        {
            links.Add(now.MyLink(i));
            now = now.MyNeighborMapNode(i);
        }

        MovingBetweenNodesController move = new MovingBetweenNodesController(links, from);
        return move;
    }
}
