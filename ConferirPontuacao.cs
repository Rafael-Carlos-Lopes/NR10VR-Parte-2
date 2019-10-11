using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ConferirPontuacao : MonoBehaviour {

	int pntConesColocados, pntCordasColocadas, pntBandeirasColocadas, pntCavar, pntLimpar, pntCinto, pntLuva, pntBota;

	float media;

	[SerializeField]
	Text nota;

	int index;

	// Use this for initialization
	void Start ()
	{
		pntConesColocados = PlayerPrefs.GetInt("PontosConesColocados");
		pntCordasColocadas = PlayerPrefs.GetInt("PontosCordasColocadas");
		pntBandeirasColocadas = PlayerPrefs.GetInt("PontosBandeirasColocadas");
		pntCavar = PlayerPrefs.GetInt("PontosCavar");
		pntLimpar = PlayerPrefs.GetInt("PontosLimpar");
		pntBota = PlayerPrefs.GetInt("PontosBota");
		pntCinto = PlayerPrefs.GetInt("PontosCinto");
		pntLuva = PlayerPrefs.GetInt("PontosLuva");

		Debug.Log ("conesColocados: " + pntConesColocados);
		Debug.Log ("cordasColocadas: " + pntCordasColocadas);
		Debug.Log ("bandeirasColocadas: " + pntBandeirasColocadas);
		Debug.Log ("Cavar: " + pntCavar);
		Debug.Log ("Limpar: " + pntLimpar);
		Debug.Log ("Bota: " + pntBota);
		Debug.Log ("cinto: " + pntCinto);
		Debug.Log ("Luva: " + pntLuva);

		PontuacaoFinal ();
	}

	void PontuacaoFinal()
	{
		media = (pntConesColocados + pntCordasColocadas + pntBandeirasColocadas + pntCavar + pntLimpar + pntBota + pntCinto + pntLuva) / 8; 

		nota.text = "Nota final: " + media.ToString();
	}
}
