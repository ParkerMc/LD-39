using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour {
	private bool flashlightOn = false;
	public Light flashlight;

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
	}
}
