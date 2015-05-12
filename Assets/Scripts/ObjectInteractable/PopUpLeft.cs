using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PopUpLeft : ObjectInteractable {
	[SerializeField]
	private GameObject leftPanel;
	[SerializeField]
	private Color colorText;
	[SerializeField]
	private string name;
	[SerializeField]
	[Multiline]
	private string description;
	
	void Awake(){
		ObjectSelected = HanldeObjectSelected;
	}
	
	private void HanldeObjectSelected(){
		Debug.Log("Building Selected");
		
		SetInformationOfPanel ();
		OpenPanel ();
		StartCoroutine (WaitToFocusLeftPanel());
	}
	
	private void OpenPanel(){
		PopUpActivator popUpActivator = leftPanel.GetComponent<PopUpActivator> ();
		if (popUpActivator != null)
			popUpActivator.PopUpOpen ();
	}

	private void ClosePanel(){
		PopUpActivator popUpActivator = leftPanel.GetComponent<PopUpActivator> ();
		if (popUpActivator != null)
			popUpActivator.PopUpExit ();
	}

	private void SetInformationOfPanel(){
		Text titleText = GetChildOfPrefabByName ("Title").GetComponent<Text> () as Text;
		titleText.color = colorText;
		Text nameText = GetChildOfPrefabByName ("Name").GetComponent<Text> () as Text;
		nameText.text = name;
		nameText.color = colorText;
		Text descriptionText = GetChildOfPrefabByName ("Description").GetComponent<Text> () as Text;
		descriptionText.text = description;
		descriptionText.color = colorText;
	}
	
	private Transform GetChildOfPrefabByName (string name)	{
		return leftPanel.gameObject.transform.FindChild (name);
	}

	IEnumerator WaitToFocusLeftPanel(){		
		stateManager.state = State.WaitingToFocusPanel;
		yield return new WaitForSeconds(4);

		if (stateManager.state == State.WaitingToFocusPanel) {
			ClosePanel ();
			stateManager.state = State.FreeFocus;
		}
	}
}
