using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Attacker))] //make sure that attacker script is present as well (or will add one
public class AttackerLizard : MonoBehaviour {

	private Animator animator;
	private Attacker attacker;

	// Use this for initialization
	void Start () {

		animator = GetComponent<Animator> ();
		attacker = GetComponent<Attacker> ();

	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D collider){ 


		GameObject collidedWith = collider.gameObject;

		//leave method if not defender
		if (!collidedWith.GetComponent<Defender>()){ return; }

		//if defender, then attack it!
		else {
			animator.SetBool ("isAttacking", true);
			attacker.Attack (collidedWith);

		}
	}
}
