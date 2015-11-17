using UnityEngine;
using System.Collections;

public class Init : MonoBehaviour {
	public int Discos = 5;
	public GameObject disco;
	private GameObject disk;
	public GameObject original;
	private float radio = 2.6f;
	private float pos = 0.2f;
	// Use this for initialization
	void Start () {
		for (int i = 0; i < Discos; i++) {
			disk = Instantiate(disco, new Vector3(original.GetComponent<Transform>().position.x, pos, original.GetComponent<Transform>().position.z), Quaternion.identity) as GameObject;
			disk.GetComponent<Disco>().SetRadio(this.radio);
			pos = pos + 0.1f;
			radio = radio - 0.2f;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
