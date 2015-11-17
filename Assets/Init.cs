using UnityEngine;
using System.Collections;

public class Init : MonoBehaviour {
	public int Discos = 3;
	public GameObject disco;
	private GameObject disk;
	public GameObject original;
	private float radio = 1.4f;
	// Use this for initialization
	void Start () {
		disk = Instantiate(disco, new Vector3(original.GetComponent<Transform>().position.x, original.GetComponent<Transform>().position.y, original.GetComponent<Transform>().position.z), Quaternion.identity) as GameObject;
		disk.GetComponent<Disco>().SetRadio(this.radio);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
