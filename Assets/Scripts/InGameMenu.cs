using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenu : MonoBehaviour {
	public UnityEngine.UI.Button backToGame;
	public UnityEngine.UI.Button exit;

	public void onBTG(){
		if (Player_look.lockMouse) {
			Cursor.lockState = CursorLockMode.Locked;
			Player_move.move = true;
			backToGame.gameObject.SetActive(false);
			exit.gameObject.SetActive(false);
			Power.pause = false;
		}
	}

	public void onExit(){
		Application.Quit ();
	}

	void OnApplicationFocus(bool hasFocus)
	{
		if (!hasFocus) {
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
			Player_move.move = false;
			backToGame.gameObject.SetActive(true);
			exit.gameObject.SetActive(true);
			Power.pause = true;
		}
	}

	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape)) {
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
			Player_move.move = false;
			backToGame.gameObject.SetActive(true);
			exit.gameObject.SetActive(true);
			Power.pause = true;
		}
	}
}
