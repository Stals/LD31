using UnityEngine;
using System.Collections;

public class CaveGoldView : MonoBehaviour {

    [SerializeField]
    public UILabel goldLabel;

    void updateGold(int amount){
        goldLabel.text = amount.ToString();
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
