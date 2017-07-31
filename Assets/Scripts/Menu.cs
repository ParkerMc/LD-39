using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {
	public GameObject gameName;
	public GameObject play;
	public GameObject howToPlay;
	public GameObject exit;

	public void onPlay(){
		UnityEngine.SceneManagement.SceneManager.LoadScene (1);
	}
	public void onHowToPlay(){
		gameName.SetActive (false);
		play.SetActive (false);
		howToPlay.SetActive (false);
		exit.SetActive (false);
	}
	public void onExit(){
		Application.Quit ();
	}
}
