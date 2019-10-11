using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleCair : MonoBehaviour {

	Animator anim;

	[SerializeField]
	GameObject raios, amigo, verificarSubirEscada;

	[SerializeField]
	bool subindo;

	void Awake()
	{
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (subindo == true) {
			if (anim.GetCurrentAnimatorStateInfo (0).normalizedTime >= 0.42f) 
			{
				verificarSubirEscada.GetComponent<VerificaSobirEscada> ().SubirEscada ();
			}
		}
	}

	public void SetCair()
	{
		anim.SetTrigger ("Caiu");
		raios.SetActive (true);
		amigo.SetActive (true);
	}
}
