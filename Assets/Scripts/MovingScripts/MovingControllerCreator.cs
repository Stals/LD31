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
}
