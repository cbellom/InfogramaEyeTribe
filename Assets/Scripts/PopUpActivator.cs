using UnityEngine;
using System.Collections;

public class PopUpActivator : MonoBehaviour {
	private Animator animator;

	void Awake(){
		animator = GetComponent<Animator> ();
	}

	void OnTriggerEnter(Collider other){
		Debug.Log ("HOla in");
		if (other.gameObject.tag == "Player")
			animator.SetBool ("Open", true);
	}

	void OnTriggerExit(Collider other){
		Debug.Log ("HOla out");
		if (other.gameObject.tag == "Player")
			animator.SetBool ("Open", false);
	}
}
