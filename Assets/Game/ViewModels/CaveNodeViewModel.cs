using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public partial class CaveNodeViewModel {

    // TODO DELETE
    public override void Interact(UnitViewModel unit)
    {
        base.Interact(unit);
        
        unit.MyBehavior = new UnitController.InCityBehavior(this);
        
        ((CaveNodeController)(Controller)).addUnit(this, unit);
    }
}
