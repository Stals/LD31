using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UniRx;


public partial class UnitView {

    void Update () {
        if (isClicked())
        {
            GameSceneManager.selectedUnit = this;
            //GameSceneManager.startNode = Unit.currentMapNode;
        }
    }
}
