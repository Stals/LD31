using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public partial class UnitViewModel
{

    UnitController.UnitBehavior myBehavior;

    public UnitController.UnitBehavior MyBehavior
    {
        get { return myBehavior; }
        set { myBehavior = value; }
    }

    Vector3 myPosition;

    public Vector3 Position
    {
        get
        {
            return myPosition;
        }

        set
        {
            myPosition = value;
        }
    }




}
