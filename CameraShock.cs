using UnityEngine;
using System.Collections;

public class CameraShock : MonoBehaviour {
	[SerializeField] Transform cameraTra, posCameraShock;
	public bool morreu = false;//variavel de morreu do script do jogador
	
	// Update is called once per frame
	void Update () {
		if (morreu){
			cameraTra.position = Vector3.MoveTowards(cameraTra.position, posCameraShock.position, 2);
			cameraTra.eulerAngles = Vector3.MoveTowards(cameraTra.eulerAngles, posCameraShock.eulerAngles, 2);
		}
	}
}
