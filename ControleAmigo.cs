using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleAmigo : MonoBehaviour {

	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetParado()
	{
		anim.SetTrigger ("Parado");
	}

	public void SetOlhando()
	{
		anim.SetTrigger ("Olhando");
	}
}
