using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UniRx;


public partial class TopPanelView {
    
	[SerializeField]
	UILabel moneyLabel;

    /// Subscribes to the property and is notified anytime the value changes.
    public override void moneyChanged(Int32 value) {
        base.moneyChanged(value);

		moneyLabel.text = value.ToString ();
    }
}
