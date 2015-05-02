using UnityEngine;
using System.Collections;

public class ResizeBoxColliderNavigationButtons : MonoBehaviour {

	void Update(){
		if (this.GetComponent<BoxCollider> ().size.x <= 1) {
			RectTransform rectTransform = this.GetComponent<RectTransform> () as RectTransform;
			Vector3 sizeDelta = rectTransform.sizeDelta;

			if(sizeDelta.x < sizeDelta.y){
				this.GetComponent<BoxCollider> ().size = new Vector3 (Screen.width - 90, sizeDelta.y, 10);
				this.GetComponent<BoxCollider> ().center = new Vector3(this.GetComponent<BoxCollider> ().center.x, GetCenterByButton(), 0);
			} else {
				this.GetComponent<BoxCollider> ().size = new Vector3 (sizeDelta.x, Screen.height - 90, 10);
				this.GetComponent<BoxCollider> ().center = new Vector3 (GetCenterByButton(), this.GetComponent<BoxCollider> ().center.y, 0);
			}
		}
	}

	private float GetCenterByButton(){
		switch (this.name) {
			case "Up":
				return -20;
			case "Down":
				return 20;
			case "Left":
				return 20;
			case "Rigth":
				return -20;
			default:
				return 0;
		}
	}

}
