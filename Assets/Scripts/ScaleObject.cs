using UnityEngine;
using System.Collections;

public class ScaleObject : ObjectInteractable{
	[SerializeField]
	private Vector3 cachedScale;
	[SerializeField]
	private Quaternion cachedRotation;
	[SerializeField]
	private float deltaScale = 1.5f;
	[SerializeField]
	private float deltaRotate = 1.5f;
	private Camera camera;	
	[SerializeField]
	private GameObject mapNavigationButtonsPanel;	
	[SerializeField]
	private GameObject rotationButtonsPanel;	

	void Awake(){
		ObjectSelected = HandleObjectSelected;
		ObjectExited = HandleObjectExited;
		cachedScale = this.gameObject.transform.localScale;
		cachedRotation = this.gameObject.transform.localRotation;
		camera = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera>() as Camera;
	}
	
	void OnApplicationQuit() {
		HandleObjectExited ();
	}

	private void HandleObjectSelected(){
		canTriggerExit = false;

		if(worldCollider != null)
			worldCollider.SetActive(false);

		ChangeOrthographicCameraTo (false);
		InactiveFamilyObjectsOf (this.gameObject);
		SetScaleObject ();	
		SetRotationObject ();

		SetActionOnSelectExitButtonOnRotationPanel ();
		Debug.Log("Change Shared");
	}
	
	private void HandleObjectExited ()	{	
		ActiveFamilyObjectsOf (this.gameObject);
		RestoreScaleObject ();
		RestoreRotationObject ();
		ChangeOrthographicCameraTo (true);
		
		canTriggerExit = true;
		if(worldCollider != null)
			worldCollider.SetActive(true);
		Debug.Log("Reset Shared");
	}

	private void SetScaleObject(){
		float xScale = this.gameObject.transform.localScale.x * deltaScale;
		float yScale = this.gameObject.transform.localScale.y * deltaScale;
		float zScale = this.gameObject.transform.localScale.z * deltaScale;

		this.gameObject.transform.localScale = new Vector3(xScale,yScale,zScale);
	}

	private void RestoreScaleObject(){
		this.gameObject.transform.localScale = new Vector3(cachedScale.x,cachedScale.y,cachedScale.z);
	}
	
	private void SetRotationObject(){		
		float xRotation = this.gameObject.transform.localRotation.x + deltaRotate;
		float yRotation = this.gameObject.transform.localRotation.y;
		float zRotation = this.gameObject.transform.localRotation.z;
		float wRotation = this.gameObject.transform.localRotation.w;
		
		this.gameObject.transform.localRotation = new Quaternion(xRotation,yRotation,zRotation, wRotation);
	}
	
	private void RestoreRotationObject(){
		this.gameObject.transform.localRotation = new Quaternion(cachedRotation.x,cachedRotation.y,cachedRotation.z, cachedRotation.w);
	}
	private void InactiveFamilyObjectsOf(GameObject son){
		Transform parent = son.transform.parent;
		for (int i=0; i < parent.childCount; i++) {
			if(son != parent.GetChild (i).gameObject){
				parent.GetChild (i).gameObject.SetActive(false);
			}
		}
		parent.gameObject.renderer.enabled = false;
		if (parent.tag != "WorldModels") {
			InactiveFamilyObjectsOf (parent.gameObject);
		}
	}

	private void ActiveFamilyObjectsOf(GameObject son){
		Transform parent = son.transform.parent;
		for (int i=0; i < parent.childCount; i++) {
			if(son != parent.GetChild (i).gameObject){
				parent.GetChild (i).gameObject.SetActive(true);
			}
		}

		parent.gameObject.renderer.enabled = true;
		if (parent.tag != "WorldModels") {
			ActiveFamilyObjectsOf (parent.gameObject);
		}
	}

	private void ChangeOrthographicCameraTo(bool isActive){
		camera.orthographic = isActive;
		mapNavigationButtonsPanel.SetActive (isActive);
		rotationButtonsPanel.SetActive (!isActive);
	}

	private void SetActionOnSelectExitButtonOnRotationPanel(){
		ObjectInteractable buttonInteractable = rotationButtonsPanel.transform.FindChild("ExitButton").GetComponent<ObjectInteractable>() as ObjectInteractable;
		buttonInteractable.SetObjectSelectedAction (HandleObjectExited);
	}
}
