using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UniRx;


public partial class EntityView { 

    /// Subscribes to the property and is notified anytime the value changes.
    public override void attackChanged(Int32 value) {
        base.attackChanged(value);
		adView.attackLabel.text = value.ToString ();
    }
 
	
	/// Subscribes to the property and is notified anytime the value changes.
	public override void defenceChanged(Int32 value) {
		adView.defenseLabel.text = value.ToString ();
	}
	
	public AttackDefenseView adView;


	[SerializeField]
	SpawnFollowingUI attackDefenseUI;
	
	public override void Awake ()
	{
		base.Awake ();

		setupAttackDefense ();
	}

	void setupAttackDefense()
	{
		//attackDefenseUI = GetComponent<SpawnFollowingUI> ();
		attackDefenseUI.createPrefab ();
		adView = attackDefenseUI.guiObject.GetComponent<AttackDefenseView> ();
	}

    public bool isClicked()
    {
        //if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D[] hits = Physics2D.GetRayIntersectionAll(ray,Mathf.Infinity);
            
            foreach (RaycastHit2D hit in hits)
            {
                if((hit.collider != null) && (hit.collider.transform == this.gameObject.transform))
                {
                    return true;
                }           
            }
        }

        return false;
    }

    public void setVisible(bool b){
        SpriteRenderer render = GetComponent<SpriteRenderer>();
        
        Color c = render.color;
        c.a = b ? 255f : 0f;
        render.color = c;
    }
}
