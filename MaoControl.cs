using UnityEngine;
using System.Collections;

public class MaoControl : MonoBehaviour {
	[SerializeField]
	GameObject mao;

	void Update () {
		if (Input.GetKey (KeyCode.JoystickButton7) || Input.GetKey (KeyCode.M))
		{
			if (mao.activeInHierarchy == false)
				mao.SetActive (true);
			mao.transform.localPosition = Vector3.Lerp (mao.transform.localPosition, new Vector3 (0.06f,-3.06f,0.33f), 5f*Time.deltaTime);
		}
		else
		{
			if (mao.activeInHierarchy == true)
			{
				mao.SetActive (false);
				mao.transform.localPosition = new Vector3 (0.06f, -3.06f, -0.31f);
			}
		}
	
	}
}
