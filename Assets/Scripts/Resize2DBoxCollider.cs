using UnityEngine;
using System.Collections;

public class Resize2DBoxCollider : MonoBehaviour {

	void Update(){
		if (this.GetComponent<BoxCollider2D> ().size.x <= 1) {
			RectTransform rectTransform = this.GetComponent<RectTransform> () as RectTransform;
			Vector2 sizeDelta = rectTransform.sizeDelta;

			if(sizeDelta.x < sizeDelta.y){
				this.GetComponent<BoxCollider2D> ().size = new Vector2 (Screen.width, sizeDelta.y);
				this.GetComponent<BoxCollider2D> ().center = new Vector2(this.GetComponent<BoxCollider2D> ().center.x, GetCenterByButton());
			} else {
				this.GetComponent<BoxCollider2D> ().size = new Vector2 (sizeDelta.x, Screen.height - 80);
				this.GetComponent<BoxCollider2D> ().center = new Vector2(GetCenterByButton(), this.GetComponent<BoxCollider2D> ().center.y);
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
