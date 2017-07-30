
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider : MonoBehaviour {

	private int[,] table = new int[3, 3] {
		{ 2, 7, 5 },
		{ 4, 8, 3 },
		{ 6, 1, 9 }
	};
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0)) {
			RaycastHit hit;
			Vector3 cameraCenter = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width / 2f, Screen.height / 2f, Camera.main.nearClipPlane));
			if (Physics.Raycast (cameraCenter, Camera.main.transform.forward, out hit, 5)) {
				GameObject obj = hit.transform.gameObject;
				Vector2 blank = new Vector2(0,0);
				Vector2 tile = new Vector2(0,0);
				if (obj.name == "1"||obj.name == "2"||obj.name == "3"||obj.name == "4"||obj.name == "5"||obj.name == "6"||obj.name == "7"||obj.name == "8") {
					int tileNum = int.Parse(obj.name);
					for (int x = 0; x <= 2; x++) {
						for (int y = 0; y <= 2; y++) {
							if (table [x, y] == 9) {
								blank = new Vector2 (x, y);
							} else if (table [x, y] == tileNum) {
								tile = new Vector2 (x, y);
							}
						}
					}
					if ((blank.y == tile.y && Mathf.Abs (blank.x - tile.x) == 1) || (blank.x == tile.x && Mathf.Abs (blank.y - tile.y) == 1)) {
						table [(int)tile.x, (int)tile.y] = 9;
						table [(int)blank.x, (int)blank.y] = tileNum;
						int x = 0;
						int y = 0;
						if (blank.x == 0) {
							x = 2;
						}else if (blank.x == 2) {
							x = -2;
						}
						if (blank.y == 0) {
							y = -2;
						}else if (blank.y == 2) {
							y = 2;
						}
						obj.transform.localPosition = new Vector3 (y, x, obj.transform.localPosition.z);
						if (table[0,0] == 1&&table[0,1] == 2&&table[0,2] == 3&&table[1,0] == 4&&table[1,1] == 5&&table[1,2] == 6&&table[2,0] == 7&&table[2,1] == 8&&table[2,2] == 9) {
							Debug.Log ("Done");
						}
					}
				}
			}
		}
	}
}
