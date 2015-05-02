using UnityEngine;
using System.Collections;

public class NavigationButton : ObjectInteractable {
	public NavigationState navigationState;

	void Awake(){
		ObjectSelected = HanldeObjectSelected;
	}

	private void HanldeObjectSelected(){
		Debug.Log("Go to " + navigationState.ToString());
	}

}
