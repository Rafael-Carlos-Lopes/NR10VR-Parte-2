using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacaoBrasao : MonoBehaviour {

	float contador = 0;

	[SerializeField]
	Transform pos1, pos2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		contador += Time.deltaTime;

		if (contador >= 0.5f) 
		{
			transform.position = Vector3.Slerp (transform.position, pos2.position, 1f * Time.deltaTime);
			transform.localScale -= new Vector3 (0.5f * Time.deltaTime, 0.5f * Time.deltaTime, 0.5f * Time.deltaTime);
		}

		if (transform.localScale.x <= 0) 
		{
			contador = 0;
			transform.localScale = new Vector3 (1, 1, 1);
			transform.position = pos1.position;
			gameObject.SetActive (false);
		}
	}
}
