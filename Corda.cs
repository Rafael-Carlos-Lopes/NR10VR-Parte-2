using UnityEngine;
using System.Collections;

public class Corda : MonoBehaviour {

	Transform destino;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () {
		if (destino == null) 
		{
			destino = GameObject.FindGameObjectWithTag("PivotDeCorda").transform;
		}

		transform.LookAt (destino);
		float distancia = Vector3.Distance (destino.position, transform.position);
		transform.localScale = new Vector3 (1f, 1f, distancia);
	}

	public void SetDestino(Transform destinoNovo)
	{
		destino = destinoNovo;
	}
}
