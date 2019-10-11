using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class PassarLogo : MonoBehaviour {

	[SerializeField]
	VideoPlayer vp;

	bool podeMudar = false;

	// Use this for initialization
	void Start () {
		Invoke ("DarUmTempinho", 2f);
	}
	
	// Update is called once per frame
	void Update () {

		if (podeMudar == true) {
			if (vp.isPlaying == false) {
				SceneManager.LoadScene ("Logo22");
			}
		}
	}

	void DarUmTempinho()
	{
		podeMudar = true;
	}
}
