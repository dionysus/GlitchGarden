using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grave : MonoBehaviour {


	public void ShakeShake(){

		GetComponent<Animator> ().SetTrigger ("underAttack");

	}


}
