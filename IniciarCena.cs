using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IniciarCena : MonoBehaviour {

	[SerializeField]
	Transform cameraCena, pos1;

	[SerializeField]
	GameObject selDoc1, selDoc2;

	// Use this for initialization
	void Start () {
		Invoke ("AtivarSelecao", 3f);
	}
	
	// Update is called once per frame
	void Update () {
		cameraCena.position = Vector3.Slerp (cameraCena.position, pos1.position, 2f * Time.deltaTime);
	}

	void AtivarSelecao()
	{
		selDoc1.SetActive (true);
		selDoc2.SetActive (true);
	}
}
