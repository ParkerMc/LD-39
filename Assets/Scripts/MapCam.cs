using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCam : MonoBehaviour {
	public GameObject camGame;
	public Camera cam;
	public Light light;
	public Light light2;

	void FixedUpdate () {
		Vector3 playerPos = camGame.transform.position;
		Vector3 playerRotate = cam.transform.rotation.eulerAngles;
		playerPos += new Vector3 (0, 300, 0);
		transform.position = playerPos;
		transform.rotation = Quaternion.Euler (90,playerRotate.y,0);
	}
	void OnPreCull () {
		light.enabled = true;
		light2.enabled = true;
	}

	void OnPreRender() {
		light.enabled = true;
		light2.enabled = true;
	}
	void OnPostRender() {
		light.enabled = false;
		light2.enabled = false;
	}
}
