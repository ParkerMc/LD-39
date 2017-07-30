using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_look : MonoBehaviour {
	public float sensitivity = 20;
	public static bool lockMouse = true;

	void Start(){
		Cursor.lockState = CursorLockMode.Locked;
	}
	void FixedUpdate () {
		if (Cursor.lockState == CursorLockMode.Locked) {
			float rotX = Input.GetAxis ("Mouse X") * sensitivity * Time.deltaTime;
			float rotY = Input.GetAxis ("Mouse Y") * sensitivity * Time.deltaTime;
			transform.localRotation = Quaternion.Euler (transform.localRotation.eulerAngles.x - rotY, transform.localRotation.eulerAngles.y + rotX, 0);
		}
	}
}
