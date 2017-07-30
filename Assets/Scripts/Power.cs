using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour {
	private bool flashlightOn = false;
	private static int power = 20;
	private static float powfloat = 1;

	public static bool pause = false;

	public Light flashlight;
	public UnityEngine.UI.Text text;
	public float lightPower;

	public static void TakePower(float amount){
		if (!pause) {
			powfloat -= amount;
			while (powfloat <= 0) {
				powfloat += 1;
				power -= 1;
				if (power < 0) {
					power = 0;
				}
			}
		}
	}

	public static bool HasPower(){
		return (power != 0);
	}

	public static int PowerLevel(){
		return power;
	}
	
	void Start() {
		flashlight.enabled = false;
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.Q)) {
			if (flashlightOn) {
				flashlight.enabled = false;
				flashlightOn = false;
			} else {
				flashlight.enabled = true;
				flashlightOn = true;
			}
		}
		if (flashlightOn) {
			TakePower (lightPower*Time.deltaTime);
			if (!HasPower()) {
				flashlight.enabled = false;
				flashlightOn = false;
			}
		}
		text.text = "Power: " + power.ToString() + "% ";
	}
}
