using UnityEngine;
using System.Collections;

public class PosEscadaOk : MonoBehaviour {
	[SerializeField]
	GameObject escadaSubir,escadaPos,localAmigoVai,amigoOBJ;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ColocarEscada()

	{
			amigoOBJ.transform.parent = localAmigoVai.transform;
			amigoOBJ.transform.localPosition = Vector3.zero;
			amigoOBJ.transform.localEulerAngles = Vector3.down*180;
			localAmigoVai.tag = "Amigo";
			localAmigoVai.GetComponent<CapsuleCollider> ().enabled = true;
			escadaPos.SetActive (false);
			escadaSubir.SetActive (true);
	}
}
