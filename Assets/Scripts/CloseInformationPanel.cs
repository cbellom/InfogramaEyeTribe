using UnityEngine;
using System.Collections;

public class CloseInformationPanel : ObjectInteractable {	
	[SerializeField]
	private GameObject worldColliderReference;

	void Awake(){
		ObjectSelected = HanldeObjectSelected;
	}

	private void HanldeObjectSelected(){
		Debug.Log("Closing Parent");
		
		elapsedTime = 0;
		isTriggerActivate = false;
		UpdateValueColorGazeIndicator ();

		if (worldColliderReference != null) 
			worldColliderReference.SetActive (true);


		this.gameObject.transform.parent.gameObject.SetActive (false);
	}
}
