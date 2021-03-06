﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {
	private bool fall = false;
	 
	public float speed = 10;

	void OnTriggerEnter(Collider other) {
		if (fall == false) {
			this.GetComponent<AudioSource> ().Play ();
			fall = true;
		}
	}
	void FixedUpdate(){
		if (fall) {
			transform.position -= new Vector3 (0, speed * Time.deltaTime, 0);
			if (transform.position.y < -10) {
				this.gameObject.SetActive (false);
				fall = false;
			}
		}
	}
}
