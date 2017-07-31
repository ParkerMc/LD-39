using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour {

	private static int power = 50;
	private static float powfloat = 1;

	public static bool pause = false;

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
}
