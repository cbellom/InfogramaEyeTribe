using UnityEngine;
using System.Collections;

public class PanelFocusManager : ObjectInteractable {
	
	void Awake(){
		ObjectSelected = HanldeObjectSelected;
		ObjectExited = HandleObjectExited;
	}
	
	private void HanldeObjectSelected(){		
		stateManager.state = State.UIFocus;		
	}

	private void HandleObjectExited ()	{	
		StartCoroutine (WaitToOutFocusLeftPanel ());
	}

	private void ClosePanel(){
		PopUpActivator popUpActivator = this.GetComponent<PopUpActivator> ();
		if (popUpActivator != null)
			popUpActivator.PopUpExit ();
	}

	IEnumerator WaitToOutFocusLeftPanel(){
		stateManager.state = State.WaitingToExitFocusPanel;
		yield return new WaitForSeconds(1);
		
		if (stateManager.state != State.UIFocus) {
			ClosePanel ();
			stateManager.state = State.FreeFocus;
		}
	}
}
