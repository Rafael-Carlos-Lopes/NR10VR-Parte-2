using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Ferramenta2 : MonoBehaviour {
	int cima = 0;

	float contador;
	
	int bip;

	[SerializeField]
	GameObject personagem, textoAnalisando,textoOk,textoBip,iniciadorPart2,ferramenta1, avisoChoque;
	[SerializeField]
	Image fade;

	bool passou = true;
	// Use this for initialization
	void Start () 
	{
		bip = Random.Range (1, 100);
		avisoChoque.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1") && cima < 2)
		{
			gameObject.transform.localPosition += new Vector3 (0, 0.1f, 0.1f);
			cima++;
		}
		else if (Input.GetButtonDown ("Fire2") && cima > -8)
		{
			gameObject.transform.localPosition -= new Vector3 (0, 0.1f, 0.1f);
			cima--;
		}
	
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.CompareTag ("Fio")) 
		{
			Debug.Log("Morreu");
			personagem.SetActive (true);
			personagem.GetComponent<CameraShake> ().SetMovendo (true);
			personagem.GetComponent<EscadaSubir> ().SetErroFatalVerd ();
			gameObject.SetActive (false);
		}
	}
	
	void OnTriggerStay(Collider col)
	{
		if (col.CompareTag ("AreaTensao"))
		{

			if (textoOk.activeInHierarchy == false && textoBip.activeInHierarchy == false)
			{
				textoAnalisando.SetActive (true);
			}
			contador += Time.deltaTime;
			
			if(contador >= 5)
			{
				if (bip < -10)
				{
					Debug.Log ("Bip");
					if (passou == true)
					{
						textoAnalisando.SetActive (false);
						textoOk.SetActive (false);
						textoBip.SetActive (true);
						Invoke ("TerminouPart1", 12f);
						passou = false;
					}
					if(fade.color.a < 1)
					fade.color += new Color (0, 0, 0, 0.1f*Time.deltaTime);
				}
				else
				{
					Debug.Log ("SemBip");
					if (passou == true)
					{
						textoAnalisando.SetActive (false);
						textoBip.SetActive (false);
						textoOk.SetActive (true);
						Invoke ("TerminouPart1", 12f);
						passou = false;
					}
					if(fade.color.a < 1)
					fade.color += new Color (0, 0, 0, 0.1f*Time.deltaTime);
				}
			}
		}
	}
	
	void OnTriggerExit(Collider col)
	{
		if (col.CompareTag ("AreaTensao")) 
		{
			contador = 0;
		}
	}
	void TerminouPart1()
	{
		Debug.Log ("OTempoParou");
		ferramenta1.SetActive (true);
		textoBip.SetActive (false);
		textoOk.SetActive (false);
		avisoChoque.SetActive (false);
		gameObject.SetActive (false);
		//iniciadorPart2.GetComponent<IniciadorDaPart2> ().SetIniciarPart2 ();
		//Time.timeScale = 0;
	}
}
