using UnityEngine;
using System.Collections;

public class AvisoDaEscada : MonoBehaviour {
	[SerializeField]
	GameObject aviso;
	void OnTriggerEnter()
	{
		if(Input.GetButton("Fire1"))
		aviso.SetActive (true);
	}
	void OnTriggerExit()
	{
		if(Input.GetButton("Fire1"))
		aviso.SetActive (false);
	}
}
