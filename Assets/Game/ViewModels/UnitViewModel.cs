using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public partial class UnitViewModel
{


    #region Classes

    abstract class UnitBehavior
    {
        public void UpdateMe(UnitViewModel unit)
        {

        }

    }


    class GoToNodeBehavior : UnitBehavior
    {
        public GoToNodeBehavior(MapNodeViewModel toNode, MapNodeViewModel fromNode)
        {

        }


    }

    #endregion

    UnitBehavior myBehavior;




}
