using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_look : MonoBehaviour {
	public float sensitivity = 20;
	public static bool lockMouse = true;

	private float rotX = 180.0f;
	private float rotY;

	void Start(){
		Cursor.lockState = CursorLockMode.Locked;
	}
	void FixedUpdate () {
		if (Cursor.lockState == CursorLockMode.Locked) {
			rotX += Input.GetAxis ("Mouse X") * sensitivity * Time.deltaTime;
			rotY -= Input.GetAxis ("Mouse Y") * sensitivity * Time.deltaTime;
			transform.localRotation = Quaternion.Euler (rotY, rotX, 0);

			if (rotY < -90.0f)
				rotY = -90.0f;
			if (rotY > 90.0f)
				rotY = 90.0f;
		}
	}
}
