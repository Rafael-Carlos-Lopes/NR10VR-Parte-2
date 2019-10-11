using UnityEngine;
using System.Collections;

public class Poste : MonoBehaviour {

	int sorteioFragilidade;//sorteio para ver se o poste vai cair ou nao
	[SerializeField]
	GameObject fusiveis;

	void Start () 
	{
		sorteioFragilidade = Random.Range (1, 60);
	}

	void OnTriggerEnter(Collider col)
	{
		//se as maos encostarem no poste
		if (col.gameObject.CompareTag ("Maos")) 
		{
			PlayerPrefs.SetInt("PontosTestarPoste", 10);//pontos por testar o poste
			if(sorteioFragilidade <= -1)
			{
				fusiveis.SetActive(false);
				GetComponent<Rigidbody>().isKinematic = false;
			}
		}
	}
}