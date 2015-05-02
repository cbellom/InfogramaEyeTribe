using UnityEngine;
using System;
using System.Collections;

public class ObjectInteractable : MonoBehaviour {
	[SerializeField]
	private float timeToTriggerAction;
	private float elapsedTime;
	private bool isTriggerActivate;
	private GameObject worldCollider;

	protected Action ObjectSelected;

	void Start(){
		worldCollider = GameObject.Find("WorldCollider");
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

		if (other.gameObject.name == "UICollider") {
			if(worldCollider != null)
				worldCollider.SetActive(true);
		}
	}
}
