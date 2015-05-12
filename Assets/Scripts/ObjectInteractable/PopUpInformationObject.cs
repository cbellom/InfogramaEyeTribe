using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PopUpInformationObject : ObjectInteractable {
	[SerializeField]
	private GameObject informationView;
	[SerializeField]
	private Sprite picture;
	[SerializeField]
	private string title;
	[SerializeField]
	[Multiline]
	private string description;

	void Awake(){
		ObjectSelected = HanldeObjectSelected;
	}
	
	private void HanldeObjectSelected(){
		Debug.Log("Building Selected");

		SetPrefabInformation ();
		informationView.SetActive (true);
		ActiveAnimationOpenInformtionView ();

		stateManager.state = State.UIFocus;

	}

	private void ActiveAnimationOpenInformtionView(){
		PopUpActivator popUpActivator = informationView.GetComponent<PopUpActivator> ();
		if (popUpActivator != null)
			popUpActivator.PopUpOpen ();
	}

	private void SetPrefabLocation(){
	}

	private void SetPrefabInformation(){
		Text titleText = GetChildOfPrefabByName ("Title").GetComponent<Text> () as Text;
		titleText.text = title;
		Text descriptionText = GetChildOfPrefabByName ("Description").GetComponent<Text> () as Text;
		descriptionText.text = description;
		Image pictureOf = GetChildOfPrefabByName ("Picture").GetComponent<Image> () as Image;
		pictureOf.sprite = picture;
	}

	private Transform GetChildOfPrefabByName (string name)	{
		return informationView.gameObject.transform.FindChild (name);
	}
}
