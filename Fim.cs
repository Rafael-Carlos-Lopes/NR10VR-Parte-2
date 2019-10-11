using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Fim : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("GameOver", 6f);
	
	}
	void GameOver()
	{
		SceneManager.LoadScene ("GameOver");
	}
}
