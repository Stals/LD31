using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public partial class CityNodeViewModel {
    public override bool ComputeHasEmptyCells()
    {
        foreach(CityCellViewModel cell in cells){
            if(cell.isEmpty){
                return true;
            }
        }
        return false;
    }
}


