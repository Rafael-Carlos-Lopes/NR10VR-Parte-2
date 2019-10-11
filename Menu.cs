using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Menu : MonoBehaviour {
	[SerializeField]
	bool cenaTempo = false;
	[SerializeField]
	bool cenaLogo = false;
	[SerializeField]
	Text[] aguarde;
	[SerializeField]
	GameObject imagemInstrucoes, imagemFichaTecnica;

	public void Iniciar()
	{
		SceneManager.LoadScene ("TempoDeAjuste");
	}
		
	void Start()
	{
        PlayerPrefs.SetInt("Errou1", 0);
        PlayerPrefs.SetInt("Errou2", 0);
        PlayerPrefs.SetInt("Errou3", 0);
        PlayerPrefs.SetInt("Errou4", 0);
        PlayerPrefs.SetInt("Pontuacao", 0);
        PlayerPrefs.SetInt("QuantidadeEscudos", 0);

        Cursor.lockState = CursorLockMode.None;//ocultando cursor
		if (cenaTempo)
		{
			aguarde[0] = GameObject.FindGameObjectWithTag ("Fusivel1").GetComponent<Text> ();
			aguarde [1] = GameObject.FindGameObjectWithTag ("Fusivel2").GetComponent<Text> ();
		}
		if (cenaLogo)
		{
			Invoke ("VaiMenu", 5f);
		}
	}
	void Update()
	{
		if(cenaTempo && Input.anyKeyDown)
		{
			//SceneManager.LoadScene ("Jogo");
			SceneManager.LoadSceneAsync ("JogoParte1");
			for(int i = 0; i < aguarde.Length; i++)
			{
				aguarde[i].text = "Aguarde...";
			}
		}

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
		//if (Input.GetButton ("Fire1") && Input.GetButton ("Fire2"))
		//{
		//	PlayerPrefs.SetString ("Leandro", "false");
		//}
		//if (Input.GetButton("Jump"))
		//{
		//	PlayerPrefs.SetString ("Leandro", "false");
		//}
	}
	public void VaiMenu()
	{
		SceneManager.LoadScene("Menu");
	}

	public void AtivarInstrucoes()
	{
		imagemInstrucoes.SetActive (true);
	}

	public void AtivarFichaTecnica()
	{
		imagemFichaTecnica.SetActive (true);
	}

	public void DesativarFichaTecnica()
	{
		imagemFichaTecnica.SetActive (false);
	}

}
