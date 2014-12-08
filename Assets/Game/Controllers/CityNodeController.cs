using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;


public class CityNodeController : CityNodeControllerBase {
    
    public override void InitializeCityNode(CityNodeViewModel cityNode) {
    }


    public override void addUnit(CityNodeViewModel cityNode, UnitViewModel arg)
    {
        base.addUnit(cityNode, arg);


        arg.MyBehavior = new UnitController.InCityBehavior(cityNode);

        arg.Position = cityNode.position;

        arg.currentMapNode = cityNode;

        /*
        cityNode.Controller

        cityNode.cells.Add(*/
    }

    public override void Interact(MapNodeViewModel mapNode, UnitViewModel arg)
    {
        base.Interact(mapNode, arg);

        addUnit((CityNodeViewModel)mapNode, arg);
    }
}
