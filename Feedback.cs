using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Feedback : MonoBehaviour {

	[SerializeField]
	GameObject feed160Parte1, feed160Parte12, feed160Parte2, feed160Parte22, feednao160, feednao1602, 
        feednao160P2, feednao160P22, feednao160P3, feednao160P32, feednao160P4, feednao160P42, 
        erro1, erro12, erro2, erro22, erro3, erro32, erro4, erro42;
	[SerializeField]
	Text numescudos, numescudos2, pont1, pont2;

	int pontuacao;
	int numEscudostotal;

	int errou1;
	int errou2;
	int errou3;
	int errou4;
    int telaAtual = 1;

    bool podePassar = false;

	// Use this for initialization
	void Start () {

		pontuacao = PlayerPrefs.GetInt ("Pontuacao");
		numEscudostotal = PlayerPrefs.GetInt ("QuantidadeEscudos");

		errou1 = PlayerPrefs.GetInt ("Errou1");
		errou2 = PlayerPrefs.GetInt ("Errou2");
		errou3 = PlayerPrefs.GetInt ("Errou3");
		errou4 = PlayerPrefs.GetInt ("Errou4");

		if (pontuacao == 150) 
		{
            feed160Parte1.SetActive(true);
            feed160Parte12.SetActive(true);
        }

		if (pontuacao < 150) {
			feednao160.SetActive (true);
			feednao1602.SetActive (true);
            numescudos.text = numEscudostotal.ToString();
            numescudos2.text = numEscudostotal.ToString();
            pont1.text = pontuacao.ToString();
            pont2.text = pontuacao.ToString();
        }
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1"))
        {
            if (podePassar == true)
			SceneManager.LoadScene ("Menu");
		}

        if (pontuacao < 150)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (telaAtual == 1)
                {
                    feednao160.SetActive(false);
                    feednao1602.SetActive(false);
                    numescudos.text = "";
                    pont1.text = "";
                    numescudos2.text = "";
                    pont2.text = "";
                    feednao160P2.SetActive(true);
                    feednao160P22.SetActive(true);
                    telaAtual = 2;
                }

                else if (telaAtual == 2)
                {
                    feednao160P2.SetActive(false);
                    feednao160P22.SetActive(false);
                    feednao160P3.SetActive(true);
                    feednao160P32.SetActive(true);

                    if (errou1 == 1)
                    {
                        erro1.SetActive(true);
                        erro12.SetActive(true);
                    }

                    if (errou2 == 1)
                    {
                        erro2.SetActive(true);
                        erro22.SetActive(true);
                    }

                    if (errou3 == 1)
                    {
                        erro3.SetActive(true);
                        erro32.SetActive(true);
                    }

                    if (errou4 == 1)
                    {
                        erro4.SetActive(true);
                        erro42.SetActive(true);
                    }
                    telaAtual = 3;
                }

                else if (telaAtual == 3)
                {
                    erro1.SetActive(false);
                    erro12.SetActive(false);
                    erro2.SetActive(false);
                    erro22.SetActive(false);
                    erro3.SetActive(false);
                    erro32.SetActive(false);
                    erro4.SetActive(false);
                    erro42.SetActive(false);

                    feednao160P3.SetActive(false);
                    feednao160P32.SetActive(false);

                    feednao160P4.SetActive(true);
                    feednao160P42.SetActive(true);

                    podePassar = true;
                }
            }
        }

        if (pontuacao == 150)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                feed160Parte1.SetActive(false);
                feed160Parte12.SetActive(false);
                feed160Parte2.SetActive(true);
                feed160Parte22.SetActive(true);
                podePassar = true;
            }
        }
    }
}
