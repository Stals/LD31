using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UniRx;


public partial class SettingsView { 
    /// Subscribes to the property and is notified anytime the value changes.
    public override void speedChanged(Single value) {
        base.speedChanged(value);
    }
}
