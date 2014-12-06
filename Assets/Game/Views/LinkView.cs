using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UniRx;


public partial class LinkView {

    public override void Awake()
    {
        base.Awake();
        Link.Initialize(transform.GetComponentInChildren<PathManager>(), Link.node1, Link.node2);
    }
}
