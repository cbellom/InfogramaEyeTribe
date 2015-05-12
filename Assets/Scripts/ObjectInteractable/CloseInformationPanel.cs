using UnityEngine;
using System.Collections;

public class CloseInformationPanel : ObjectInteractable {	
	[SerializeField]
	private GameObject worldColliderReference;
	[SerializeField]
	private GameObject informationView;

	void Awake(){
		ObjectSelected = HanldeObjectSelected;
	}

	private void HanldeObjectSelected(){
		Debug.Log("Closing Parent");
		
		elapsedTime = 0;
		isTriggerActivate = false;
		UpdateValueColorGazeIndicator ();

		ActiveAnimationExitInformtionView ();

		stateManager.state = State.FreeFocus;
		
	}

	private void ActiveAnimationExitInformtionView(){
		PopUpActivator popUpActivator = informationView.GetComponent<PopUpActivator> ();
		if (popUpActivator != null)
			popUpActivator.PopUpExit ();
	}
}
