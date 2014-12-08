using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;


public class CaveNodeController : CaveNodeControllerBase {
    
    public override void InitializeCaveNode(CaveNodeViewModel caveNode) {
    }

    public override void addUnit(CaveNodeViewModel caveNode, UnitViewModel arg)
    {
        base.addUnit(caveNode, arg);

        arg.Position = caveNode.position;
        
        arg.currentMapNode = caveNode;

        arg.MyBehavior = new UnitController.InCityBehavior(caveNode);
        
        /*
        cityNode.Controller

        cityNode.cells.Add(*/
    }

    public override void Interact(MapNodeViewModel mapNode, UnitViewModel arg)
    {
        base.Interact(mapNode, arg);

        addUnit((CaveNodeViewModel)mapNode, arg);
    }
}
