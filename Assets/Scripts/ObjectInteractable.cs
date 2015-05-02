using UnityEngine;
using System;
using System.Collections;

public class ObjectInteractable : MonoBehaviour {
	[SerializeField]
	private float timeToTriggerAction;
	private float elapsedTime;
	private bool isTriggerActivate;

	protected Action ObjectSelected;
	
	void OnTriggerEnter(Collider other) {
		elapsedTime = 0;
		isTriggerActivate = false;
		Debug.Log("Enter");      
	}
	
	void OnTriggerStay(Collider other) {
		if (!isTriggerActivate) {
			elapsedTime += Time.deltaTime;
			if (elapsedTime >= timeToTriggerAction) {
				Debug.Log ("+++++ Ejecutar accion");
				isTriggerActivate = true;
				if(ObjectSelected != null)
					ObjectSelected();
			}
			Debug.Log ("Stay " + elapsedTime);
		}
	}
	
	void OnTriggerExit(Collider other) {
		elapsedTime = 0;
		isTriggerActivate = false;
		Debug.Log("Exit");       
	}
}
