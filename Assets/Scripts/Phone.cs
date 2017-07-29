using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : MonoBehaviour {
	private bool open = false;
	private bool moving = false;
	private float x;
	private float y;
	private float size;
	private RectTransform rt;
	private Vector3 oldPos;

	public UnityEngine.UI.Image screen;
	public float moveSpeed;
	public float zoomSpeed;

	void Start(){
		
	}
	void FixedUpdate(){
		if (Input.GetButton ("Fire1")&&!moving) {
			if (!open) {
				Player_look.lockMouse = false;
				moving = true;
				Cursor.lockState = CursorLockMode.None;
				rt = this.GetComponent<RectTransform> ();
				oldPos = rt.position;
				rt.anchorMin = new Vector2 (.5f, .5f);
				rt.anchorMax = new Vector2 (.5f, .5f);
				rt.position = oldPos;
				open = true;
			}else if (open) {
				Player_look.lockMouse = true;
				moving = true;
				screen.color = new Color32(0, 0, 0, 255);
				Cursor.lockState = CursorLockMode.Locked;
				rt = this.GetComponent<RectTransform> ();
				oldPos = rt.position;
				rt.anchorMin = new Vector2 (0, 0);
				rt.anchorMax = new Vector2 (0, 0);
				rt.position = oldPos;
				open = false;
			}
		}
		if (moving && open) {
			rt = this.GetComponent<RectTransform> ();
			if ((x = rt.localPosition.x + (moveSpeed * Time.deltaTime)) > -120) {
				x = -120;
			}
			if ((y = rt.localPosition.y + (moveSpeed * Time.deltaTime)) > -200) {
				y = -200;
			}
			if ((size = rt.localScale.x + (zoomSpeed * Time.deltaTime)) > 4){
				size = 4;
			}
			if (x == -120 && y == -200 && size == 4) {
				moving = false;
				screen.color = new Color32(255, 255, 255, 225);
			}
			rt.localScale = new Vector3 (size, size, size);
			rt.localPosition = new Vector3 (x, y, rt.localPosition.z);
		} else if (moving) {
			rt = this.GetComponent<RectTransform> ();
			if ((x = (rt.localPosition.x) - (moveSpeed * Time.deltaTime)) < -340) {
				x = -340;
			}
			if ((y = rt.localPosition.y - (moveSpeed * Time.deltaTime)) < -270) {
				y = -270;
			}
			if ((size = rt.localScale.x - (zoomSpeed * Time.deltaTime)) < 1.5){
				size = 1.5f;
			}
			if (x == -340 && y == -270 && size == 1.5) {
				moving = false;
			}
			rt.localScale = new Vector3 (size, size, size);
			rt.localPosition = new Vector3 (x, y, rt.localPosition.z);

		}
	}
}
