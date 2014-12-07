using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UniRx;


public partial class MapNodeView {

    public override void Awake()
    {
        base.Awake();

        MapNode.position = transform.position;
    }

	// Update is called once per frame
	void Update () {
        if (isClicked())
        {
            onNodeClicked();
        }
	}

    public virtual bool CanGoTo()
    {
        return true;
    }

	void onNodeClicked()
	{
        if (!CanGoTo())
        {
            GameSceneManager.selectedUnit = null;
            return;
        }

        if ((GameSceneManager.selectedUnit != null) &&
            (GameSceneManager.selectedUnit.Unit.currentMapNode != MapNode))
        {
            //GameSceneManager.endNode = this;
            // create path, ect, ect

            GameSceneManager.selectedUnit.ExecuteGoTo(MapNode);

            GameSceneManager.selectedUnit = null;
        }
	}
}
