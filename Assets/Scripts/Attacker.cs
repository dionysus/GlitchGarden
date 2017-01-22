using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {

	//PUBLICS

	public float screenMin = -2f;

	[Tooltip ("Average number of seconds between appearances")]
	public float seenEverySeconds;

	// PRIVATES

	private float currentSpeed;
	private GameObject currentTarget;
	private Health enemyHealth;
	private Animator animator;



	// Use this for initialization
	void Start () {

		// add kinematic rigidbody2D
		Rigidbody2D myRigidbody = gameObject.AddComponent<Rigidbody2D> ();
		myRigidbody.isKinematic = true;

		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.left * currentSpeed * Time.deltaTime);

		if (!currentTarget) {
			animator.SetBool ("isAttacking", false);
		}

		if (transform.position.x <= screenMin){ Destroy (gameObject);}
	}
		
	// called from animator at time of strike
	public void StrikeCurrentTarget (float damage){

		if (currentTarget) {
			enemyHealth = currentTarget.GetComponent<Health> ();

			if (enemyHealth) {
				enemyHealth.DealDamage (damage);
			
			} 
		} 
	}

	// target of attack
	public void Attack (GameObject attackTarget){
		
		currentTarget = attackTarget;

	}

	public void SetSpeed (float speed){

		currentSpeed = speed;

	}
		

}
