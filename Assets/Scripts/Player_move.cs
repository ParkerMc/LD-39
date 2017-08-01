using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_move : MonoBehaviour {
	public float sensitivity = 50f;
	public float jumpSpeed = 60f;
	public AudioSource footstepSource;
	public GameObject resetText;

	public static bool move = true;

	private float disToGround;

	void Start(){
		disToGround = this.GetComponentInParent<Collider>().bounds.extents.y;
	}

	void FixedUpdate () {
		if (Input.GetKeyDown (KeyCode.R)) {
			UnityEngine.SceneManagement.SceneManager.LoadScene (1);
		}
		if (transform.localPosition.y < -10) {
			resetText.SetActive (true);
		}
		if(move){
			//Move along x and z
			float Xaxes =  Input.GetAxis("Horizontal");
			float Zaxes =  Input.GetAxis("Vertical");

			Vector3 movement = new Vector3 (Xaxes, 0.0f, Zaxes).normalized;
			Xaxes = movement.x;
			Zaxes = movement.z;

			Rigidbody rb = this.GetComponent<Rigidbody>();
			float speed = 1f;
			if (Input.GetButton ("Fire3")) {
				speed = 2f;
			}
			rb.velocity = ((Zaxes * new Vector3 (Camera.main.transform.forward.x,0,Camera.main.transform.forward.z)) + ( Xaxes * new Vector3 (Camera.main.transform.right.x,0,Camera.main.transform.right.z))) * Time.deltaTime  * speed * sensitivity + new Vector3 (0, rb.velocity.y, 0);

			footstepSource.pitch = new Vector2 (Xaxes, Zaxes).magnitude * speed;
			//Jump
			//if (Input.GetButton ("Jump") && Physics.Raycast (transform.position, -Vector3.up, disToGround + 0.1f)) {
			//	rb.AddForce (Vector3.up * jumpSpeed);
			//}
		}
	}
}
