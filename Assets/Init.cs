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
	public Material[] colores;
	private float radio = 2.6f;
	private float posO = 0.2f;
	private float posA = 0.2f;
	private float posD = 0.2f;
	public static Stack<GameObject> Origen = new Stack<GameObject>();
	public static Stack<GameObject> Aux = new Stack<GameObject>();
	public static Stack<GameObject> Destino = new Stack<GameObject>();
<<<<<<< HEAD
	List<Material> lista;
=======
	private float vel = 0f;
	private float esperar = 0f;
	private bool wait = true;
	public static GameObject[] MovG = new GameObject[64];
	public static float[] MovV1 = new float[64];
	public static float[] MovV2 = new float[64];
	public static float[] MovV3 = new float[64];
	public int k = 0;
	private int j = 0;

>>>>>>> Programadas iteraciones, falta perfeccionar animaciones
	// Use this for initialization
	void Start () {
		lista = new List<Material> (colores);
		for (int i = 0; i < Discos; i++) {
<<<<<<< HEAD
			while (lista.Count>0) {
				disk = Instantiate(disco, new Vector3(original.GetComponent<Transform>().position.x, posO, original.GetComponent<Transform>().position.z), Quaternion.identity) as GameObject;
				disk.GetComponent<Disco>().SetRadio(this.radio);
				int x= Random.Range(0,lista.Count-1);
				disk.GetComponent<Disco>().setMaterial(lista[x]);
				posO = posO + 0.1f;
				radio = radio - 0.2f;
				Origen.Push(disk);
				lista.RemoveAt(x);
			}
=======
			disk = Instantiate(disco, new Vector3(original.transform.position.x, posO, original.transform.position.z), Quaternion.identity) as GameObject;
			disk.GetComponent<Disco>().SetRadio(this.radio);
			posO = posO + 0.1f;
			radio = radio - 0.2f;
			Origen.Push(disk);
>>>>>>> Programadas iteraciones, falta perfeccionar animaciones
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(j < k && !wait)
		{
			if(esperar + 1 > Time.time)// arriba
			{
				MovG[j].transform.Translate (new Vector3(0,MovV1[j],0));
			}
			else
			{
				if(esperar + 2 > Time.time)//izq-der
				{
					MovG[j].transform.Translate (new Vector3(MovV2[j],0,0));
				}
				else
				{
					if(esperar + 3 > Time.time)//abajo
					{
						MovG[j].transform.Translate (new Vector3(0,-MovV3[j],0));
					}
					else
					{
						esperar = Time.time;
						j++;
					}
				}
			}
		}
	}
	public void Hanoi()
	{
		ResolverHanoi (Discos,Origen,Destino,Aux,original,final,auxiliar,posO,posD,posA);
		wait = false;
		esperar = Time.time;
	}
	private void ResolverHanoi(int n, Stack<GameObject> T1, Stack<GameObject>T2, Stack<GameObject>T3, GameObject O, GameObject F, GameObject A, float Po, float Pf, float Pa)
	{
		if(n == 1)
		{
			GameObject Dis1 = T1.Pop ();
			T2.Push(Dis1);
			AnimacionMover(Dis1,O,F,Po,Pf);
			Po = Po - 0.1f;
			//Dis1.transform.position = new Vector3(F.transform.position.x,Pf,F.transform.position.z);// sin animacion
			Pf = Pf + 0.1f;
		}
		else
		{
			ResolverHanoi (n-1,T1,T3,T2,O,A,F,Po,Pa,Pf);
			GameObject Dis2 = T1.Pop ();
			T2.Push(Dis2);
			AnimacionMover(Dis2,O,F,Po,Pf);
			Po = Po - 0.1f;
			//Dis2.transform.position = new Vector3(F.transform.position.x,Pf,F.transform.position.z);// sin animacion
			Pf = Pf + 0.1f;
			ResolverHanoi (n-1,T3,T2,T1,A,F,O,Pa,Pf,Po);
		}
	}
	private void AnimacionMover(GameObject disc, GameObject o, GameObject f, float po, float pf)
	{
		MovG[k] = disc;
		vel = ((o.transform.position.y+(o.transform.position.y/2))-po)/60;
		MovV1[k] = vel;
		//Debug.Log ("arriba: "+ vel);
		if(o.transform.position.x < f.transform.position.x)
		{
			vel = (f.transform.position.x-o.transform.position.x)/60;
			MovV2[k] = vel;
			//Debug.Log ("der: "+ (vel));
		}
		else
		{
			vel = (o.transform.position.x - f.transform.position.x)/60;
			MovV2[k] = -vel;
			//Debug.Log ("izq: "+ vel);
		}
		vel = ((o.transform.position.y+(o.transform.position.y/2))-pf)/60;
		MovV3[k] = vel;		
		//Debug.Log ("abajo: "+ vel);
		k++;
	}
}
