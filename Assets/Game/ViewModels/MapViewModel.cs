using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public partial class MapViewModel {
	List<MapNodeViewModel> getNodes(){
		return GraphManager.Instance.MapNodes;
	}
}
