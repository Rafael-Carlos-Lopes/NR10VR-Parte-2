using UnityEngine;
using System.Collections;

public class CaiuDaEscada : MonoBehaviour {
	[SerializeField]
	GameObject ferramenta,control,player,playerControlavel,particula;
	bool caiu = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (caiu) {
			control.GetComponent<CameraShake> ().SetMovendo (true);
		}
		
	}
	void OnTriggerEnter(Collider outro)
	{
		if (outro.gameObject.CompareTag ("Player"))
		{
			//outro.gameObject.GetComponent<Rigidbody> ().mass = 0.2f;
			caiu = true;
			player.SetActive(true);
			player.GetComponent<EscadaSubir>().SetControlavel(false);
			player.GetComponent<EscadaSubir>().SetCaido();
			gameObject.GetComponent<AudioSource> ().Play ();
			particula.SetActive(true);
			playerControlavel.GetComponent<JoystickSetupDemo>().enabled = false;
			ferramenta.SetActive (false);
		}
	}
}
