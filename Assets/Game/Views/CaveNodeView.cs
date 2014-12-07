using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UniRx;


public partial class CaveNodeView { 

    int[] gold = {5,11,18,27,40,61,98,167,300, 561, 0};
    int[] attack = {2,9,16,24,31,38,46,54,61, 69, 0};
    int[] defense = {15,36,58,82,110,146,198,282,430, 706, 0};

    /// Subscribes to the property and is notified anytime the value changes.
    public override void goldLevelChanged(Int32 value) {
        base.goldLevelChanged(value);

        CaveNode.gold = gold [value - 1];

        if (goldView)
        {
            goldView.goldLabel.text = CaveNode.gold.ToString();
        }
    }

    /// Subscribes to the property and is notified anytime the value changes.
    public override void attackLevelChanged(Int32 value) {
        base.attackLevelChanged(value);

		
        CaveNode.attack = attack[value - 1];
    }

    /// Subscribes to the property and is notified anytime the value changes.
    public override void defenseLevelChanged(Int32 value) {
        base.defenseLevelChanged(value);

        CaveNode.defence = defense[value - 1];
    }

    [SerializeField]
    SpawnFollowingUI goldUI;

    CaveGoldView goldView;

    public override void Awake()
    {
        base.Awake();
        if (goldUI != null)
        {
            goldUI.createPrefab();
            goldView = goldUI.guiObject.GetComponent<CaveGoldView>();
        }
    }

}
