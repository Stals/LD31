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
		attackDefenseUI = GetComponent<SpawnFollowingUI> ();
		attackDefenseUI.createPrefab ();
		adView = attackDefenseUI.guiObject.GetComponent<AttackDefenseView> ();
	}
}
