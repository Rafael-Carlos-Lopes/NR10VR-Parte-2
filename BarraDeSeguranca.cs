using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeSeguranca : MonoBehaviour {
	[SerializeField]
	Sprite[] sprites, spritesEscudos;
	int pontuacao = 0, numImagem = 0;
	int quantidadeEscudos = 0;
	Image im;
	[SerializeField]
	GameObject barra;

    [SerializeField]
    Image imEscudos;

	[SerializeField]
	bool pegarInformacoes;
	// Use this for initialization

	void Start () {
		im = GetComponent<Image> ();
		DontDestroyOnLoad (barra);

        if (pegarInformacoes == true)
		{
			pontuacao = PlayerPrefs.GetInt ("Pontuacao");

			im.sprite = sprites [(pontuacao / 5)];

			quantidadeEscudos = PlayerPrefs.GetInt("QuantidadeEscudos");

            imEscudos.sprite = spritesEscudos[quantidadeEscudos];
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AumentarBarra(int valor)
	{
        if (valor == 5)
        {
            pontuacao = pontuacao + 5;
            numImagem = (pontuacao/5);
            im.sprite = sprites[numImagem];
        }
		if (valor == 10) 
		{
            pontuacao = pontuacao + 10;
            numImagem = (pontuacao/5);
            im.sprite = sprites[numImagem];
        }
	}

	public void AumentarEscudos()
	{
        if (quantidadeEscudos < 12)
        {
            quantidadeEscudos++;
            imEscudos.sprite = spritesEscudos[quantidadeEscudos];
        }
	}

	public void SetarPontuacao()
	{
		PlayerPrefs.SetInt ("Pontuacao", pontuacao);
		PlayerPrefs.SetInt ("QuantidadeEscudos", quantidadeEscudos);
	}
}
