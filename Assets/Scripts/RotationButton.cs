using UnityEngine;
using System;
using System.Collections;

public class RotationButton : ObjectInteractable {
	public DirectionState directionState;

	public Action ButtonClicked;

	void Awake(){
		ObjectSelected = HandleObjectSelected;
	}
	
	private void HandleObjectSelected(){
		if (ButtonClicked != null)
			ButtonClicked ();

		elapsedTime = timeToTriggerAction - 0.05f;
		isTriggerActivate = false;
	}


}
