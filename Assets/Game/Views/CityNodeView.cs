using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UniRx;


public partial class CityNodeView { 

    /// Subscribes to the property and is notified anytime the value changes.
    public override void maxCellsChanged(Int32 value) {
        base.maxCellsChanged(value);

		grid.cellsCountChanged (value);
    }

	[SerializeField]
	SpawnFollowingUI gridUI;

	CellsGridView grid;

	public override void Awake ()
	{
		base.Awake ();

		setupCells ();
	}

	void setupCells()
	{
        CityCellView[] viewCells = GetComponentsInChildren<CityCellView>();
        foreach (CityCellView cell in viewCells)
        {
            //CityNode.cells.Add(cell.CityCell);
            //cell.setVisible(false);
        }

		//gridUI.createPrefab ();
		//grid = gridUI.guiObject.GetComponent<CellsGridView>();
	}

    public virtual bool CanGoTo()
    {
        return CityNode.HasEmptyCells;
    }

}
