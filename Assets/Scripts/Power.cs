using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour {
	private bool flashlightOn = false;
	private Animator animator;
	private bool animationDone = true;

	private static int power = 20;
	private static float powfloat = 1;

	public static bool pause = false;

	public Light flashlight;
	public UnityEngine.UI.Text text;
	public float lightPower;

	public static void TakePower(float amount){
		if (!pause) {
			powfloat -= amount;
			while (powfloat <= 0) {
				powfloat += 1;
				power -= 1;
				if (power < 0) {
					power = 0;
				}
			}
		}
	}

	public static bool HasPower(){
		return (power != 0);
	}

	public static int PowerLevel(){
		return power;
	}
	
	void Start() {
		flashlight.enabled = false;
		animator = this.GetComponentInChildren<Animator> ();
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.F)&&animationDone) {
			if (flashlightOn) {
				animationDone = false;
				flashlightOn = false;
				animator.SetBool ("flashlight", false);
				animator.SetBool ("armUp", false);
			} else {
				animationDone = false;
				flashlightOn = true;
				animator.SetBool ("flashlight", true);
				animator.SetBool ("armUp", true);
			}
		}
		if (!animationDone) {
			if(animator.GetCurrentAnimatorStateInfo (0).IsName("TurningFlashlightOn")&&animator.GetCurrentAnimatorStateInfo (0).normalizedTime > .426){
				flashlight.enabled = true;
				animationDone = true;
			}else if(animator.GetCurrentAnimatorStateInfo (0).IsName("TurningFlashlightOff")&&animator.GetCurrentAnimatorStateInfo (0).normalizedTime > .492){
				flashlight.enabled = false;
				animationDone = true;
			}
		}else if (flashlightOn) {
			TakePower (lightPower*Time.deltaTime);
			if (!HasPower()) {
				flashlight.enabled = false;
				flashlightOn = false;
				//Todo make power off at once
				animator.SetBool ("flashlight", false);
			}
		}
		text.text = "Power: " + power.ToString() + "% ";
	}
}
