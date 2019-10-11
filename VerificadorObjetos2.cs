using UnityEngine;
using System.Collections;
//se for para a escada, colocque um collider trigger no poste e coloque a tag "Poste" no poste

public class VerificadorObjetos2 : MonoBehaviour {
	[SerializeField]
	bool jaManipulou = false;
	Vector3 posicaoInicial;
	public Collider colisor;

	void Start(){
		colisor = GetComponent<BoxCollider> ();
		posicaoInicial = transform.position;
	}

	public bool getJaManipulou(){
		return jaManipulou;
	}

	public void SetJaManipulou(bool valor){
		jaManipulou = valor;
	}

	public Vector3 getPosicaoInicial(){
		return posicaoInicial;
	}

	void OnTriggerEnter(Collider outro){
		Debug.Log ("Entrou Em Colisao");
		if (outro.tag == "Poste")
			colisor = outro;
	}

	void OnTriggerExit(){
		Debug.Log ("Saiu Da Colisao");
		colisor = null;
	}
	
	public Collider getColisor(){
		return colisor;
	}
}
