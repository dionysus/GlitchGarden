using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	public float health = 50f;

	public void DealDamage (float damage){

		health -= damage;

		if (health < 0) {
			//optionally trigger death animation
			DestroyObject ();
		}
			
	}

	public float GetHealth (){ return health; }


	public void DestroyObject (){

		Destroy (gameObject);

	}

}
