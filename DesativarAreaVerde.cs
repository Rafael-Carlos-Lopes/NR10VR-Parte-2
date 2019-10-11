using UnityEngine;
using System.Collections;

public class DesativarAreaVerde : MonoBehaviour {

	void OnTriggerEnter(Collider col)
	{
		if (col.tag.Equals ("Item") || col.tag.Equals ("ItemColocado")) 
		{
			gameObject.SetActive(false);
		}
	}
}
