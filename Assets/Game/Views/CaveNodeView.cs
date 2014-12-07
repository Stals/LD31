using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UniRx;


public partial class CaveNodeView { 

    /// Subscribes to the property and is notified anytime the value changes.
    public override void goldLevelChanged(Int32 value) {
        base.goldLevelChanged(value);

		CaveNode.attack = value;
    }

    /// Subscribes to the property and is notified anytime the value changes.
    public override void attackLevelChanged(Int32 value) {
        base.attackLevelChanged(value);

		//CaveNode.attack = value;
    }

    /// Subscribes to the property and is notified anytime the value changes.
    public override void defenseLevelChanged(Int32 value) {
        base.defenseLevelChanged(value);

		CaveNode.defence = value;
    }

}
