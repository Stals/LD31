using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UniRx;


public partial class CityCellView {
    public void setVisible(bool b){
        SpriteRenderer render = GetComponent<SpriteRenderer>();

        Color c = render.color;
        c.a = b ? 255f : 0f;
        render.color = c;
    }
}
