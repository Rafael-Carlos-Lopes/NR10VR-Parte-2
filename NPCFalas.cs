using UnityEngine;
using System.Collections;

public class NPCFalas : MonoBehaviour {
	[SerializeField]
	AudioClip[] ajuda,boaSinaSOM,bomTrabSOM,posteFirmeSOM,cintoSOM,ajudaEsq,centralSOM;
	[SerializeField]
	AudioClip[] ajudaALT,boaSinaSOMALT,bomTrabSOMALT,posteFirmeSOMALT,cintoSOMALT,ajudaEsqALT,centralSOMALT;
	AudioSource emisor;
	bool egg = false;
	bool boaSina = false;
	bool bomTrab = false;
	bool posteFirme = false;
	bool cinto = false;
	bool ajudabool = false;
	bool central = false;

	void Start()
	{
		emisor = gameObject.GetComponent<AudioSource> ();
		if (PlayerPrefs.GetString ("Leandro") == "true")
		{
			egg = true;
		}
		else
		{
			egg = false;
		}
	}
	public void SetFala1()
	{
		int n = Random.Range (0, 2);
		if(egg == false)
			emisor.clip = ajuda[n];
		else
			emisor.clip = ajudaALT[n];
		emisor.Play ();
	}
	public void SetBoaSina()
	{
		if (boaSina == false && emisor.isPlaying == false)
		{
			int n = Random.Range (0, 5);
			if(egg == false)
				emisor.clip = boaSinaSOM [n];
			else
				emisor.clip = boaSinaSOMALT [n];
			emisor.Play ();
			boaSina = true;
		}
	}
	public void SetBomTrab()
	{
		if (bomTrab == false && emisor.isPlaying == false)
		{
			int n = Random.Range (0, 2);
			if(egg == false)
				emisor.clip = bomTrabSOM [n];
			else
				emisor.clip = bomTrabSOMALT [n];
			emisor.Play ();
			bomTrab = true;
		}
	}
	public void SetPosteFirme()
	{
		if (posteFirme == false && emisor.isPlaying == false)
		{
			int n = Random.Range (0, 2);
			if(egg == false)
				emisor.clip = posteFirmeSOM[n];
			else
				emisor.clip = posteFirmeSOMALT[n];
			emisor.Play ();
			posteFirme = true;
		}
	}
	public void SetCinto()
	{
		if (cinto == false && emisor.isPlaying == false)
		{
			int n = Random.Range (0, 4);
			if(egg == false)
				emisor.clip = cintoSOM[n];
			else
				emisor.clip = cintoSOMALT[n];
			emisor.Play ();
			cinto = true;
		}
	}
	public void SetAjudaEsq()
	{
		if (ajudabool == false && emisor.isPlaying == false)
		{
			int n = Random.Range (0, 3);
			if(egg == false)
				emisor.clip = ajudaEsq[n];
			else
				emisor.clip = ajudaEsqALT[n];
			emisor.Play ();
			ajudabool = true;
		}
	}
	public void SetCentral()
	{
		if (central == false && emisor.isPlaying == false)
		{
			int n = Random.Range (0, 2);
			if(egg == false)
				emisor.clip = centralSOM[n];
			else
				emisor.clip = centralSOMALT[n];
			emisor.Play ();
			central = true;
		}
	}
}
