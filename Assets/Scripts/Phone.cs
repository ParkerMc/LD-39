using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : MonoBehaviour {
	public GameObject pannel;
	public GameObject lockText;
	public GameObject screenLight;
	public GameObject map;

	private bool animationDone = true;
	void Start () {
		pannel.SetActive (true);
		lockText.SetActive (true);
		screenLight.SetActive (true);
	}
	

	void Update () {
		if (Input.GetKeyDown (KeyCode.M) && animationDone) {
			
		}
	}
}
