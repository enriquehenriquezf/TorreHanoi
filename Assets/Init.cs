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
	List<Material> lista;
	private bool wait = true;
	public static GameObject[] MovG = new GameObject[64];
	public static float[] MovV1 = new float[64];
	public static float[] MovV2 = new float[64];
	public static int[] DirV2 = new int[64];
	public static float[] MovV3 = new float[64];
	public int k = 0;
	private int j = 0;
	private bool subiendo = false;

	// Use this for initialization
	void Start () {
		lista = new List<Material> (colores);
		while (lista.Count>0) {
			disk = Instantiate(disco, new Vector3(original.transform.position.x, posO, original.transform.position.z), Quaternion.identity) as GameObject;
			disk.GetComponent<Disco>().SetRadio(this.radio);
			int x= Random.Range(0,lista.Count-1);
			disk.GetComponent<Disco>().setMaterial(lista[x]);
			posO = posO + 0.1f;
			radio = radio - 0.4f;
			Origen.Push(disk);
			lista.RemoveAt(x);
		}		
		posO = posO - 0.1f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(j < k && !wait)
		{
			if(MovG[j].transform.position.y < MovV1[j] && subiendo)// arriba
			{
				MovG[j].transform.Translate (new Vector3(0,2*Time.deltaTime,0));
			}
			else
			{
				if(MovG[j].transform.position.x < MovV2[j] && DirV2[j] == 1)//der
				{
					MovG[j].transform.Translate (new Vector3(2*Time.deltaTime,0,0));
					if(subiendo)
					{
						subiendo = false;
					}
				}
				else
				{
					if(MovG[j].transform.position.x > MovV2[j] && DirV2[j] == -1)//izq
					{
						MovG[j].transform.Translate (new Vector3(-(2*Time.deltaTime),0,0));
						if(subiendo)
						{
							subiendo = false;
						}
					}
					else
					{
						if(MovG[j].transform.position.y > MovV3[j])//abajo
						{
							MovG[j].transform.Translate (new Vector3(0,-2*Time.deltaTime,0));
						}
						else
						{
							j++;							
							subiendo = true;
						}
					}
				}
			}
		}
	}
	public void Hanoi()
	{
		ResolverHanoi (Discos,Origen,Destino,Aux,original,final,auxiliar,posO,posD,posA);
		subiendo = true;
		wait = false;
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
		MovV1[k] = 3;// arriba
		if(o.transform.position.x < f.transform.position.x)
		{
			MovV2[k] = f.transform.position.x;// der
			DirV2[k] = 1;
		}
		else
		{
			MovV2[k] = f.transform.position.x;//izq
			DirV2[k] = -1;
		}
		MovV3[k] = pf;//abajo
		k++;
	}
}
