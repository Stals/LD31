using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;


public class UnitController : UnitControllerBase
{

    public void initOnCreation(MapNodeViewModel nowCity)
    {

    }

    public override void InitializeUnit(UnitViewModel unit) {
        unit.state = UnitState.InCity;

    }
}
