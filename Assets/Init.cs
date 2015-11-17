using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Init : MonoBehaviour {
	public int Discos = 5;
	public GameObject disco;
	private GameObject disk;
	public GameObject original;
	public GameObject auxiliar;
	public GameObject final;
	private float radio = 2.6f;
	private float posO = 0.2f;
	private float posA = 0.2f;
	private float posD = 0.2f;
	public static Stack<GameObject> Origen = new Stack<GameObject>();
	public static Stack<GameObject> Aux = new Stack<GameObject>();
	public static Stack<GameObject> Destino = new Stack<GameObject>();
	// Use this for initialization
	void Start () {
		for (int i = 0; i < Discos; i++) {
			disk = Instantiate(disco, new Vector3(original.GetComponent<Transform>().position.x, posO, original.GetComponent<Transform>().position.z), Quaternion.identity) as GameObject;
			disk.GetComponent<Disco>().SetRadio(this.radio);
			posO = posO + 0.1f;
			radio = radio - 0.2f;
			Origen.Push(disk);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void Hanoi()
	{
		ResolverHanoi (Discos,Origen,Destino,Aux,original,final,auxiliar,posO,posD,posA);
	}
	public void ResolverHanoi(int n, Stack<GameObject> T1, Stack<GameObject>T2, Stack<GameObject>T3, GameObject O, GameObject F, GameObject A, float Po, float Pf, float Pa)
	{
		if(n == 1)
		{
			GameObject Dis1 = T1.Pop ();
			T2.Push(Dis1);
			Po = Po - 0.1f;
			Dis1.transform.position = new Vector3(F.transform.position.x,Pf,F.transform.position.z);
			Pf = Pf + 0.1f;
			//Origen.Pop();
		}
		else
		{
			ResolverHanoi (n-1,T1,T3,T2,O,A,F,Po,Pa,Pf);
			GameObject Dis2 = T1.Pop ();
			T2.Push(Dis2);
			Po = Po - 0.1f;
			Dis2.transform.position = new Vector3(F.transform.position.x,Pf,F.transform.position.z);
			Pf = Pf + 0.1f;
			//Origen.Pop ();
			ResolverHanoi (n-1,T3,T2,T1,A,F,O,Pa,Pf,Po);
		}
	}
}
