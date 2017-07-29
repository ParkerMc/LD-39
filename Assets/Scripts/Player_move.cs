using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_move : MonoBehaviour {
	public float sensitivity = 50f;
	public float jumpSpeed = 60f;
	private float disToGround;

	void Start(){
		disToGround = this.GetComponent<Collider> ().bounds.extents.y;
	}

	void FixedUpdate () {
		//Move along x and z
		float Xaxes =  Input.GetAxis("Horizontal");
		float Zaxes =  Input.GetAxis("Vertical");
		Rigidbody rb = this.GetComponent<Rigidbody>();
		float speed = 1f;
		if (Input.GetButton ("Fire3")) {
			speed = 2f;
		}
		rb.velocity = new Vector3 (0, rb.velocity.y, 0) + (Zaxes * new Vector3 (transform.forward.x,0,transform.forward.z)) + ( Xaxes * new Vector3 (transform.right.x,0,transform.right.z)) * Time.deltaTime  * speed * sensitivity;
		//Jump
		if (Input.GetButton ("Jump") && Physics.Raycast (transform.position, -Vector3.up, disToGround + 0.1f)) {
			rb.AddForce (Vector3.up * jumpSpeed);
		}
	}
}
