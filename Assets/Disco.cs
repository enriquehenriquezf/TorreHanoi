using UnityEngine;
using System.Collections;

public class Disco : MonoBehaviour {
	public float radio = 2.6f;
	// Use this for initialization
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
}
