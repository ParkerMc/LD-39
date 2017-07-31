using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCam : MonoBehaviour {
	public float speed;
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.Euler (transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + speed*Time.deltaTime, transform.rotation.eulerAngles.z);
	}
}
