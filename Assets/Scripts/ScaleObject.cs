using UnityEngine;
using System.Collections;

public class ScaleObject : ObjectInteractable{
	[SerializeField]
	private Vector3 cachedScale;
	[SerializeField]
	private float scale = 1.5f;
	
	void Awake(){
		ObjectSelected = HandleObjectSelected;
		ObjectExited = HandleObjectExited;
		cachedScale = this.gameObject.transform.localScale;
	}
	
	void OnApplicationQuit() {
		HandleObjectExited ();
	}
	private void HandleObjectSelected(){
		SetScaleObject ();		
		Debug.Log("Change Shared");
	}
	
	private void HandleObjectExited ()	{
		RestoreScaleObject ();
		Debug.Log("Reset Shared");
	}

	private void SetScaleObject(){
		float xScale = this.gameObject.transform.localScale.x * scale;
		float yScale = this.gameObject.transform.localScale.y * scale;
		float zScale = this.gameObject.transform.localScale.z * scale;
		
		this.gameObject.transform.localScale = new Vector3(xScale,yScale,zScale);
	}

	private void RestoreScaleObject(){
		this.gameObject.transform.localScale = new Vector3(cachedScale.x,cachedScale.y,cachedScale.z);
	}

}
