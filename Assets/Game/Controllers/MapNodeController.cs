using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;


public class MapNodeController : MapNodeControllerBase {

    public override void InitializeMapNode(MapNodeViewModel mapNode)
    {
        MapInstance.AddMapNode(mapNode);
    }
}
