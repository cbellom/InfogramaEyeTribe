using UnityEngine;
using System.Collections;

public class StandOutObject : ObjectInteractable {
	void Awake(){
		ObjectSelected = HanldeObjectSelected;
	}

	private void HanldeObjectSelected(){
		Debug.Log("Change Color");
	}
}
