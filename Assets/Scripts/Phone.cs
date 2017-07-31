using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//todo after animation change map code
public class Phone : MonoBehaviour {
	public GameObject home;
	public GameObject topBar;
	public GameObject flashlight;
	public GameObject map;
	public GameObject flashlightL;
	public GameObject phoneLight;
	public UnityEngine.UI.Text powerLevel;
	public float lightPower;
	public float mapPower;
	private int powLev;
	private bool mapUp = false;
	private bool flashlightOn = false;
	private bool screenOn = false;
	private Animator animator;

	void Start(){
		animator = this.GetComponentInParent<Animator> ();
	}
	

	void Update () {
		if (animator.GetCurrentAnimatorStateInfo (0).IsName ("armUp") && !screenOn) {
			topBar.SetActive (true);
			home.SetActive (true);
			phoneLight.SetActive (true);
			screenOn = true;
		} else if (animator.GetCurrentAnimatorStateInfo (0).IsName ("TurningPhoneOff")&&screenOn&&animator.GetCurrentAnimatorStateInfo(0).normalizedTime > .275) {
			phoneLight.SetActive (false);
			topBar.SetActive (false);
			home.SetActive (false);
			screenOn = false;
		} else if(animator.GetCurrentAnimatorStateInfo (0).IsName("TurningFlashlightOn")&&animator.GetCurrentAnimatorStateInfo (0).normalizedTime > .426&&!flashlightOn){
			home.SetActive (false);
			flashlight.SetActive (true);
			flashlightL.SetActive (true);
			flashlightOn = true;
		}else if(animator.GetCurrentAnimatorStateInfo (0).IsName("TurningFlashlightOff")&&animator.GetCurrentAnimatorStateInfo (0).normalizedTime > .492&&flashlightOn){
			home.SetActive (true);
			flashlight.SetActive (false);
			flashlightL.SetActive (false);
			flashlightOn = false;
		}
		if (Input.GetKeyDown (KeyCode.M)&&Power.HasPower()) {
			if (!mapUp) {
				animator.SetBool ("armUp", true);
				animator.SetBool ("flashlight", false);
				home.SetActive (false);
				map.SetActive (true);
				mapUp = true;
			} else {
				animator.SetBool ("armUp", false);
				home.SetActive (true);
				map.SetActive (false);
				mapUp = false;
			}
		} else if (Input.GetKeyDown (KeyCode.F)&&Power.HasPower()) {
			if (!flashlightOn) {
				map.SetActive (false);
				mapUp = false;
				animator.SetBool ("armUp", true);
				animator.SetBool ("flashlight", true);
			} else {
				animator.SetBool ("armUp", false);
				animator.SetBool ("flashlight", false);
			}
		}

		if (flashlightOn) {
			Power.TakePower (lightPower * Time.deltaTime);
		}else if (mapUp) {
			Power.TakePower (mapPower * Time.deltaTime);
		}
		if (!Power.HasPower()) {
			flashlight.SetActive(false);
			topBar.SetActive (false);
			home.SetActive (false);
			map.SetActive (false);
			flashlightL.SetActive (false);
			flashlightOn = false;
			mapUp = false;
			animator.SetBool ("power", false);
		}
		powLev = Power.PowerLevel ();
		if (powLev >= 37) {
			powerLevel.text = "\\uf242 " + powLev.ToString () + "%";
		}else if (powLev >= 12) {
			powerLevel.text = "\\uf243 " + powLev.ToString () + "%";
		}else {
			powerLevel.text = "\\uf244 " + powLev.ToString () + "%";
		}
	}
}
