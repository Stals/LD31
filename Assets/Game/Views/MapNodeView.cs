using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UniRx;


public partial class MapNodeView {

	// Update is called once per frame
	void Update () {
        if (isClicked())
        {
            onNodeClicked();
        }
	}

	void onNodeClicked()
	{
        if (GameSceneManager.selectedUnit != null)
        {
            //GameSceneManager.endNode = this;
            // create path, ect, ect

            GameSceneManager.selectedUnit.ExecuteGoTo(MapNode);

            GameSceneManager.selectedUnit = null;
        }
	}
}
