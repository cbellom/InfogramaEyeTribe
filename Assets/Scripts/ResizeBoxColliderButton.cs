using UnityEngine;
using System.Collections;

public class ResizeBoxColliderButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update(){
		if (this.GetComponent<BoxCollider> ().size.x <= 1) {
			RectTransform rectTransform = this.GetComponent<RectTransform> () as RectTransform;
			Vector3 sizeDelta = rectTransform.sizeDelta;
			
			this.GetComponent<BoxCollider> ().size = new Vector3 (sizeDelta.x, sizeDelta.y, 10);
			this.GetComponent<BoxCollider> ().center = new Vector3(-sizeDelta.x/2, sizeDelta.y/2, 0);

		}
	}
}
