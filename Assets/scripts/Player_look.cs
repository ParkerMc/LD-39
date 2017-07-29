using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_look : MonoBehaviour {
	public float sensitivityX;
	public float sensitivityY;

	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape)) {
			Cursor.lockState = CursorLockMode.None;
		}else if (Input.GetMouseButtonDown (0)) {
			Cursor.lockState = CursorLockMode.Locked;
		}
		if (Cursor.lockState == CursorLockMode.Locked) {
			float rotX = Input.GetAxis ("Mouse X") * sensitivityX;
			float rotY = Input.GetAxis ("Mouse Y") * sensitivityY;
			transform.localRotation = Quaternion.Euler (transform.localRotation.eulerAngles.x - rotY, transform.localRotation.eulerAngles.y + rotX, 0);
		}
	}
}
