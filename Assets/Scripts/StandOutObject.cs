using UnityEngine;
using System.Collections;

public class StandOutObject : ObjectInteractable {
	[SerializeField]
	private Shader cachedShared;

	void Awake(){
		ObjectSelected = HandleObjectSelected;
		ObjectExited = HandleObjectExited;
		cachedShared = this.gameObject.renderer.sharedMaterial.shader;
	}

	void OnApplicationQuit() {
		HandleObjectExited ();
	}

	private void HandleObjectSelected(){
		Shader shared = Shader.Find("Self-Illumin/Bumped Specular");
		this.gameObject.renderer.sharedMaterial.shader = shared;

		Debug.Log("Change Shared");
	}
	
	private void HandleObjectExited ()	{
		this.gameObject.renderer.sharedMaterial.shader = cachedShared;
		
		Debug.Log("Reset Shared");
	}
}
