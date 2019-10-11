using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestarBotoes : MonoBehaviour {

	[SerializeField]
	Text teto;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Joystick1Button0)) 
		{
			teto.text = "0";
		}

		if (Input.GetKeyDown (KeyCode.Joystick1Button1)) 
		{
			teto.text = "1";
		}

		if (Input.GetKeyDown (KeyCode.Joystick1Button2)) 
		{
			teto.text = "2";
		}

		if (Input.GetKeyDown (KeyCode.Joystick1Button3)) 
		{
			teto.text = "3";
		}

		if (Input.GetKeyDown (KeyCode.Joystick1Button4)) 
		{
			teto.text = "4";
		}

		if (Input.GetKeyDown (KeyCode.Joystick1Button5)) 
		{
			teto.text = "5";
		}

		if (Input.GetKeyDown (KeyCode.Joystick1Button6)) 
		{
			teto.text = "6";
		}

		if (Input.GetKeyDown (KeyCode.Joystick1Button7)) 
		{
			teto.text = "7";
		}

		if (Input.GetKeyDown (KeyCode.Joystick1Button8)) 
		{
			teto.text = "8";
		}

		if (Input.GetKeyDown (KeyCode.Joystick1Button9)) 
		{
			teto.text = "9";
		}

		if (Input.GetKeyDown (KeyCode.Joystick1Button10)) 
		{
			teto.text = "10";
		}

		if (Input.GetKeyDown (KeyCode.Joystick1Button11)) 
		{
			teto.text = "11";
		}

		if (Input.GetKeyDown (KeyCode.Joystick1Button12)) 
		{
			teto.text = "12";
		}

		if (Input.GetKeyDown (KeyCode.Joystick1Button13)) 
		{
			teto.text = "13";
		}

		if (Input.GetKeyDown (KeyCode.Joystick1Button14)) 
		{
			teto.text = "14";
		}


		if (Input.GetKeyDown (KeyCode.Joystick1Button15)) 
		{
			teto.text = "15";
		}

		if (Input.GetKeyDown (KeyCode.Joystick1Button16)) 
		{
			teto.text = "16";
		}

		if (Input.GetKeyDown (KeyCode.Joystick1Button17)) 
		{
			teto.text = "17";
		}

		if (Input.GetKeyDown (KeyCode.Joystick1Button18)) 
		{
			teto.text = "18";
		}

		if (Input.GetKeyDown (KeyCode.JoystickButton19)) 
		{
			teto.text = "19";
		}
	}
}
