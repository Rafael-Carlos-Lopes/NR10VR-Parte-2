using UnityEngine;
using System.Collections;

public class VerificadorObjetos : MonoBehaviour {

	Collider colisor;
	Vector3 posicaoInicial;
	bool jaManipulou = false;

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
		if (outro.tag == "Poste")
			colisor = outro;
	}
	
	void OnTriggerExit(){
		//Debug.Log ("Saiu Da Colisao");
		colisor = null;
	}
	
	public Collider getColisor(){
		return colisor;
	}
}
