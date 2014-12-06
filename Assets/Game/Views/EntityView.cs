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

	SpawnFollowingUI ui;
	public AttackDefenseView adView;


	public override void Awake ()
	{
		base.Awake ();

		ui = GetComponent<SpawnFollowingUI> ();
		ui.createPrefab ();
		adView = ui.guiObject.GetComponent<AttackDefenseView> ();
		
		adView.attackLabel.text = Entity.attack.ToString ();
		adView.defenseLabel.text = Entity.defence.ToString ();
	}

}
