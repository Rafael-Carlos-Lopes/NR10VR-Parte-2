using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instrucoes : MonoBehaviour {

	int telaAtual;
	[SerializeField]
	Sprite[] sprites;
	[SerializeField]
	GameObject botaoAvancar, botaoRetroceder, botaoVoltar;
	Image imagemInstrucoes;

	// Use this for initialization
	void Start ()
	{
		imagemInstrucoes = GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.RightArrow)) 
		{
			switch (telaAtual) 
			{
				case 0:
					imagemInstrucoes.sprite = sprites [1];
					telaAtual++;
					break;

				case 1:
					imagemInstrucoes.sprite = sprites [2];
					telaAtual++;
					break;
			}
		}	

		if (Input.GetKeyDown (KeyCode.LeftArrow)) 
		{
			switch (telaAtual) 
			{
			case 2:
				imagemInstrucoes.sprite = sprites [1];
				telaAtual--;
				break;

			case 1:
				imagemInstrucoes.sprite = sprites [0];
				telaAtual--;
				break;
			}
		}	

		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			telaAtual = 0;
			imagemInstrucoes.sprite = sprites [0];
			gameObject.SetActive (false);
		}
	}

	public void Avancar()
	{
		switch (telaAtual) 
		{
			case 0:
				imagemInstrucoes.sprite = sprites [1];
				botaoRetroceder.SetActive (true);
				telaAtual++;
				break;

			case 1:
				imagemInstrucoes.sprite = sprites [2];
				//botaoAvancar.SetActive (false);
				telaAtual++;
				break;

			case 2:
				imagemInstrucoes.sprite = sprites [3];
				//botaoAvancar.SetActive (false);
				telaAtual++;
				break;

			case 3:
				telaAtual = 4;
				imagemInstrucoes.sprite = sprites [4];
				botaoAvancar.SetActive (false);
				break;
			
		}
	}


	public void Retroceder()
	{
		switch (telaAtual) 
		{
			case 4:
				imagemInstrucoes.sprite = sprites [3];
				botaoAvancar.SetActive (true);
				telaAtual--;
				break;

			case 3:
				imagemInstrucoes.sprite = sprites [2];
				telaAtual--;
				break;

			case 2:
				imagemInstrucoes.sprite = sprites [1];
				telaAtual--;
				break;

			case 1:
				imagemInstrucoes.sprite = sprites [0];
				botaoRetroceder.SetActive (false);
				telaAtual--;
				break;
		}
	}


	public void Desativar()
	{
		telaAtual = 0;
		imagemInstrucoes.sprite = sprites [0];
		botaoRetroceder.SetActive (false);
		botaoAvancar.SetActive (true);
		gameObject.SetActive (false);
	}

}
