using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class IniciadorDaPart2 : MonoBehaviour {
	[SerializeField]
	GameObject ferramenta1,ferramenta2,npcDescer,textoBip,player,camVR,areaFim;
	[SerializeField]
	RuntimeAnimatorController anim;
	[SerializeField]
	BoxCollider colPe;
	[SerializeField]
	Image fade;
	[SerializeField]
	GameObject[] itensRemover;
	[SerializeField]
	Image[] maoIMG;
	bool suprema = false;
	public void SetIniciarPart2()
	{
		suprema = true;
		ferramenta1.SetActive (false);
		ferramenta2.SetActive (false);
		textoBip.SetActive (false);
		fade.color = new Color (0,0,0,0);
		npcDescer.SetActive (true);
		npcDescer.GetComponent<Animator> ().runtimeAnimatorController = anim;
		npcDescer.GetComponent<EscadaSubir> ().SetControlavel (false);
		colPe.enabled = true;
		npcDescer.GetComponent<EscadaSubir> ().SetSubirEscada ();
		npcDescer.GetComponent<Animator> ().speed = 1;
		Invoke ("Delay", 1f);
		npcDescer.GetComponent<CameraShake> ().SetMovendo (true);
		maoIMG[0].enabled = true;
		maoIMG[1].enabled = true;
		itensRemover = GameObject.FindGameObjectsWithTag ("BandeiraColocada");
		areaFim.SetActive (true);
		for (int i = 0; i < itensRemover.Length; i++)
		{
			itensRemover [i].GetComponent<BoxCollider> ().enabled = true;
			itensRemover [i].tag = "Remover";
		}
	}
	void Delay()
	{
		npcDescer.GetComponent<Animator> ().speed = 0;
		npcDescer.GetComponent<EscadaSubir> ().SetControlavel (true);
	}
	void OnTriggerEnter(Collider outro)
	{
		if (outro.gameObject.CompareTag ("PePlayer"))
		{
			npcDescer.SetActive (false);
			player.transform.position = new Vector3 (6.21f, 2.82f, -3.37f);
			camVR.transform.localPosition = new Vector3 (0, 0, 0);
			camVR.transform.localEulerAngles = new Vector3 (0, 0, 0);
		}
	}
	public bool GetSumprema()
	{
		return suprema;
	}
}
