using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UniRx;


public partial class CaveNodeView { 

    int[] gold = {5,11,18,27,40,61,98,167,300, 0, 0};
    int[] attack = {2,9,16,24,31,38,46,54,61, 0, 0};
    int[] defense = {15,36,58,82,110,146,198,282,430, 0, 0};

    /// Subscribes to the property and is notified anytime the value changes.
    public override void goldLevelChanged(Int32 value) {
        base.goldLevelChanged(value);

        CaveNode.gold = gold [value];
    }

    /// Subscribes to the property and is notified anytime the value changes.
    public override void attackLevelChanged(Int32 value) {
        base.attackLevelChanged(value);

		
        CaveNode.attack = attack[value];
    }

    /// Subscribes to the property and is notified anytime the value changes.
    public override void defenseLevelChanged(Int32 value) {
        base.defenseLevelChanged(value);

        CaveNode.defence = defense[value];
    }

}
