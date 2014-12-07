using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public partial class CityCellViewModel {

    public override bool ComputeisEmpty()
    {
        return unit == null;
    }
}
