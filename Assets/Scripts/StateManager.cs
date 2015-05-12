using UnityEngine;
using System.Collections;

public class StateManager : MonoBehaviour {

	public State state;
	public GameObject worldCollider;
	public GameObject uiCollider;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (state == State.FreeFocus) {
			worldCollider.SetActive (true);
			uiCollider.SetActive(true);
		} else if (state == State.UIFocus) {
			worldCollider.SetActive (false);
			uiCollider.SetActive(true);
		} else if (state == State.WaitingToFocusPanel) {
			worldCollider.SetActive (false);
			uiCollider.SetActive(true);
		}else if (state == State.WaitingToExitFocusPanel) {
			worldCollider.SetActive (false);
			uiCollider.SetActive(true);
		}

	}
}
