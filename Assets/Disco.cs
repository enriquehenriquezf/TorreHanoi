using UnityEngine;
using System.Collections;

public class Disco : MonoBehaviour {
	public float radio = 2.6f;
	// Use this for initialization
	Material material;
	void Start () {
		transform.localScale = new Vector3(radio,transform.localScale.y,radio);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void SetRadio(float r)
	{
		radio = r;
	}
	public void setMaterial(Material mat)
	{
		material = mat;
		this.gameObject.GetComponent<SkinnedMeshRenderer>().material = material;
	}
}


	

