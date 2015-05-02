using UnityEngine;
using System;
using System.Collections;

public class ObjectInteractable : MonoBehaviour {
	[SerializeField]
	protected float timeToTriggerAction;
	protected float elapsedTime;
	protected bool isTriggerActivate;
	protected GameObject worldCollider;
	private GameObject gazeIndicator;

	protected Action ObjectSelected;

	void Start(){
		worldCollider = GameObject.Find("WorldCollider");
		gazeIndicator = GameObject.FindWithTag("gazeIndicator");
	}

	void OnTriggerEnter(Collider other) {
		elapsedTime = 0;
		isTriggerActivate = false;

		if (other.gameObject.name == "UICollider") {
			if(worldCollider != null)
				worldCollider.SetActive(false);
		}  
	}
	
	void OnTriggerStay(Collider other) {
		if (!isTriggerActivate) {
			elapsedTime += Time.deltaTime;
			UpdateValueColorGazeIndicator();
			if (elapsedTime >= timeToTriggerAction) {
				isTriggerActivate = true;
				if(ObjectSelected != null)
					ObjectSelected();
			}
		}
	}
	
	void OnTriggerExit(Collider other) {
		elapsedTime = 0;
		isTriggerActivate = false;
		UpdateValueColorGazeIndicator ();
		if (other.gameObject.name == "UICollider") {
			if(worldCollider != null)
				worldCollider.SetActive(true);
		}
	}

	private void UpdateValueColorGazeIndicator(){
		BindCircleForShader bindCircle = gazeIndicator.GetComponent<BindCircleForShader>() as BindCircleForShader;
		bindCircle.SetValue (elapsedTime/timeToTriggerAction);
	}
}
