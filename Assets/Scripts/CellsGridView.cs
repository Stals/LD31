using UnityEngine;
using System.Collections;

public class CellsGridView : MonoBehaviour {

	UIGrid grid;

	[SerializeField]
	GameObject cellPrefab;

	public void cellsCountChanged(int value){
		grid = GetComponent<UIGrid>();

		int size = grid.GetChildList().size;
		
		while (value > size) {
			NGUITools.AddChild(grid.gameObject, cellPrefab);
			grid.Reposition();
			++size;
		}
		
		while (value < size && (size > 0)) {
			Transform t = grid.GetChild(0);
			grid.RemoveChild(t);
			NGUITools.Destroy(t.gameObject);
			--size;
		}
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
