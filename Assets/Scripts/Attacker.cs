using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {

	//PUBLICS

	private float screenMin = 0f;

	[Tooltip ("Average number of seconds between appearances")]
	public float seenEverySeconds;

	// PRIVATES

	private float currentSpeed;
	private GameObject currentTarget;
	private Health enemyHealth;
	private Animator animator;
	private LosePanel losePanel;

	void Start () {

		//define variables


		//attach references
		losePanel = GameObject.FindObjectOfType<LosePanel>();
		animator = GetComponent<Animator> ();

		// add kinematic rigidbody2D
		Rigidbody2D myRigidbody = gameObject.AddComponent<Rigidbody2D> ();
		myRigidbody.isKinematic = true;


	}
	

	void Update () {
		
		transform.Translate (Vector3.left * currentSpeed * Time.deltaTime);

		if (!currentTarget) {
			animator.SetBool ("isAttacking", false);
		}

		if (transform.position.x <= screenMin){
			losePanel.LoseAnimation ();
		}

	}
		
	// called from animator at time of strike
	public void StrikeCurrentTarget (float damage){

		if (currentTarget) {
			enemyHealth = currentTarget.GetComponent<Health> ();

			if (enemyHealth) {
				enemyHealth.DealDamage (damage);

				if (currentTarget.GetComponent<Grave> ()) { 
					currentTarget.GetComponent<Grave> ().ShakeShake ();

				}

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
