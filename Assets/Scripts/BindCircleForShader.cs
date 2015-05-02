using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BindCircleForShader : MonoBehaviour 
{
    [SerializeField]
    private Color start;
    [SerializeField]
    private Color end;
    [SerializeField]
    private Material CircleMaterial;
	[SerializeField]
	private float value;
		
	void Update () 
    {
		CircleMaterial.SetFloat("_Angle", Mathf.Lerp(-3.14f, 3.14f, value));
		CircleMaterial.SetColor("_Color", Color.Lerp(start, end, value));
	}

	public void SetValue(float value){
		this.value = value;
	}
}
