using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour {
	public GameObject text;
	public GameObject button;

	void OnTriggerEnter(Collider other) {
		text.SetActive(true);
		button.SetActive (true);
		Power.pause = true;
		Player_move.move = false;
		Cursor.lockState = CursorLockMode.None;
		other.GetComponent<Rigidbody> ().useGravity = false;
		other.GetComponent<Rigidbody> ().isKinematic = true;
	}
}