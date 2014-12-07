using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UniRx;


public partial class UnitView {

    public override void Awake()
    {
        base.Awake();
        Unit.Controller.Initialize(Unit, Unit.currentMapNode
    }
}
