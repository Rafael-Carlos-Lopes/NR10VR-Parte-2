using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuJogo : MonoBehaviour {

	[SerializeField] GameObject iconeSom1, iconeSom2, seletor, seletor2, menuJogo, menuJogo2, telaControles, telaControles2,
	mira, ferramenta1, ferramenta1Parte2, characterControler, controlDocs1, controlDocs2, controlEpis1, controlEpis2,
	controlInsp1, controlInsp2, verifEquips1, verifEquips2, passarEpis1, passarEpis2, textoSom1, textoSom2, textoSair1,
	textoSair2, textoControles1, textoControles2;

	[SerializeField] Transform pos1, pos2, pos3, pos12, pos22, pos32;

	[SerializeField] Sprite[] sprites;

	AudioSource som;

	bool comSom = true;

	bool pausado = false;

	int posicao;
	float delay = 0.5f;
	bool podeMexer = true;
	bool instrucoesLigadas = false;

	// Use this for initialization
	void Start () {
		som = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Joystick1Button4) || Input.GetKeyDown(KeyCode.Escape)) 
		{
			if (menuJogo.activeInHierarchy == false)
			{	
				menuJogo2.SetActive (true);
				menuJogo.SetActive (true);
				if(mira != null)
				mira.GetComponent<Mira> ().SetPausado (true);
				if(characterControler != null)
				characterControler.GetComponent<CharacterController> ().enabled = false;
				
				if (controlDocs1 != null)
					controlDocs1.GetComponent<SeleçãoDocumentos> ().SetPausado (true);
				if (controlDocs2 != null)
					controlDocs2.GetComponent<SeleçãoDocumentos> ().SetPausado (true);
				
				if (controlEpis1 != null)
					controlEpis1.GetComponent<SelecaoEPIs> ().SetPausado (true);
				if (controlEpis2 != null)
					controlEpis2.GetComponent<SelecaoEPIs> ().SetPausado (true);

				if (controlInsp1 != null)
					controlInsp1.GetComponent<InspecaoDocumentos> ().SetPausado (true);
				if (controlInsp2 != null)
					controlInsp2.GetComponent<InspecaoDocumentos> ().SetPausado (true);

				if (verifEquips1 != null)
					verifEquips1.GetComponent<VerificarEscolhaEquipamentos> ().SetPausado (true);
				if (verifEquips2 != null)
					verifEquips2.GetComponent<VerificarEscolhaEquipamentos> ().SetPausado (true);

				if (passarEpis1 != null)
					passarEpis1.GetComponent<PassarEpis> ().SetPausado (true);
				if (passarEpis2 != null)
					passarEpis2.GetComponent<PassarEpis> ().SetPausado (true);
			}
			else 
			{
				menuJogo.SetActive (false);
				menuJogo2.SetActive (false);
				mira.GetComponent<Mira> ().SetPausado (false);
				if(characterControler != null)
				characterControler.GetComponent<CharacterController> ().enabled = true;
				
				if (controlDocs1 != null)
					controlDocs1.GetComponent<SeleçãoDocumentos> ().SetPausado (false);
				if (controlDocs2 != null)
					controlDocs2.GetComponent<SeleçãoDocumentos> ().SetPausado (false);
				
				if (controlEpis1 != null)
					controlEpis1.GetComponent<SelecaoEPIs> ().SetPausado (false);
				if (controlEpis2 != null)
					controlEpis2.GetComponent<SelecaoEPIs> ().SetPausado (false);
				
				if (controlInsp1 != null)
					controlInsp1.GetComponent<InspecaoDocumentos> ().SetPausado (false);
				if (controlInsp2 != null)
					controlInsp2.GetComponent<InspecaoDocumentos> ().SetPausado (false);

				if (verifEquips1 != null)
					verifEquips1.GetComponent<VerificarEscolhaEquipamentos> ().SetPausado (false);
				if (verifEquips2 != null)
					verifEquips2.GetComponent<VerificarEscolhaEquipamentos> ().SetPausado (false);

				if (passarEpis1 != null)
					passarEpis1.GetComponent<PassarEpis> ().SetPausado (false);
				if (passarEpis2 != null)
					passarEpis2.GetComponent<PassarEpis> ().SetPausado (false);
			}
		}

		if (menuJogo.activeInHierarchy == true) 
		{
			if (instrucoesLigadas == false) {
				if (Input.GetAxis ("Horizontal") < 0) {
					if (podeMexer == true) {
						if (posicao == 2) {
							posicao = 1;
							seletor.transform.position = pos2.position;
							seletor2.transform.position = pos22.position;
							textoControles1.SetActive (false);
							textoControles2.SetActive (false);
							textoSair1.SetActive (true);
							textoSair2.SetActive (true);
						} else if (posicao == 1) {
							posicao = 0;
							seletor.transform.position = pos1.position;
							seletor2.transform.position = pos12.position;
							textoSair1.SetActive (false);
							textoSair2.SetActive (false);
							textoSom1.SetActive (true);
							textoSom2.SetActive (true);
						}
						podeMexer = false;
					}
				} else if (Input.GetAxis ("Horizontal") > 0) {
					if (podeMexer == true) {
						if (posicao == 0) {
							posicao = 1;
							seletor.transform.position = pos2.position;
							seletor2.transform.position = pos22.position;
							textoSom1.SetActive (false);
							textoSom2.SetActive (false);
							textoSair1.SetActive (true);
							textoSair2.SetActive (true);
						} else if (posicao == 1) {
							posicao = 2;
							seletor.transform.position = pos3.position;
							seletor2.transform.position = pos32.position;
							textoSair1.SetActive (false);
							textoSair2.SetActive (false);
							textoControles1.SetActive (true);
							textoControles2.SetActive (true);
						}
						podeMexer = false;
					}
				}

				if (podeMexer == false) {
					delay -= Time.deltaTime;

					if (delay <= 0) {
						delay = 0.3f;
						podeMexer = true;
					}
				}
			}
		}

		if (Input.GetButtonDown ("Fire1")) {
			if (menuJogo.activeInHierarchy == true) {
				if (posicao == 1)
					Application.Quit ();

				if (posicao == 0) {
					if (comSom == true) {
						iconeSom1.GetComponent<Image> ().sprite = sprites [1];
						iconeSom2.GetComponent<Image> ().sprite = sprites [1];
						if (som != null)
							som.volume = 0;
						comSom = false;	
					} else if (comSom == false) {
						iconeSom1.GetComponent<Image> ().sprite = sprites [0];
						iconeSom2.GetComponent<Image> ().sprite = sprites [0];
						if (som != null)
							som.volume = 1;
						comSom = true;
					}
				}
				
				if (posicao == 2) {
					if (instrucoesLigadas == false) {
						telaControles.SetActive (true);
						telaControles2.SetActive (true);
						instrucoesLigadas = true;
					} else if (instrucoesLigadas == true) {
						telaControles.SetActive (false);
						telaControles2.SetActive (false);
						instrucoesLigadas = false;
					}
				}
			}
		}
	}

}
