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

        arg.currentMapNode = cityNode;

        /*
        cityNode.Controller

        cityNode.cells.Add(*/
    }
}
