using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	[Range (0f, 2f)]
	public float projectileSpeed;
	public float projectileDamage = 10f;

	private int screenMax = 14;

	//private Rigidbody2D projectileRB;

	// Use this for initialization
	void Start () {

		// add kinematic rigidbody2D
		Rigidbody2D myRigidbody = gameObject.AddComponent<Rigidbody2D> ();
		myRigidbody.isKinematic = true;

		
	}
	
	// Update is called once per frame
	void Update () {

		transform.Translate (Vector3.right * projectileSpeed * Time.deltaTime);

		if (transform.position.x >= screenMax){ Destroy (gameObject);}

	}


	void OnTriggerEnter2D(Collider2D collider){ 

		GameObject collidedWith = collider.gameObject;
		Attacker attacker = collidedWith.GetComponent<Attacker> ();
		Health enemyHealth = collider.GetComponent<Health> ();

		//leave method if not defender
		if (attacker && enemyHealth){
			
			enemyHealth.DealDamage (projectileDamage);
			DestroySelf();

		}
	}

	void DestroySelf(){

		Destroy (gameObject);

	}

}
