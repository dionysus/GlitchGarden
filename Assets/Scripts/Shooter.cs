using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

	public GameObject projectileType, projectileSpawn;

	private GameObject projectileParent;
	private Animator animator;
	private Spawner myLaneSpawner;

	void Start (){

		animator = GetComponent<Animator> ();

	// find/create projectiles folder for spawned projectiles
		projectileParent = GameObject.Find ("Projectiles");

		if (!projectileParent) {
			projectileParent = new GameObject ("Projectiles");
		}

		SetMyLaneSpawner ();
			
	}

	void Update (){

		if (IsAttackerAheadInLane ()) {
			animator.SetBool ("isAttacking", true);
		} else {
			animator.SetBool ("isAttacking", false);
		}
			
	}

	private void Fire (){

		Object.Instantiate (projectileType, projectileSpawn.transform.position, Quaternion.identity, projectileParent.transform);
	
	}

	void SetMyLaneSpawner (){

		Spawner[] spawnerArray = GameObject.FindObjectsOfType<Spawner> ();

		foreach (Spawner spawner in spawnerArray) {
			if (spawner.transform.position.y == transform.position.y) {
				myLaneSpawner = spawner;
				Debug.Log ("in lane " + myLaneSpawner);
				return;
			}
		}
	}
		

	public bool IsAttackerAheadInLane (){

		// exit if none in lane
		if (myLaneSpawner.transform.childCount <= 0) { 
			Debug.Log ("no enemies");
			return false;
		}

		// if there are attackers, are there any ahead?

		foreach (Transform attacker in myLaneSpawner.transform) { // look for transforms within transform
			if (attacker.transform.position.x > transform.position.x) {
				Debug.Log ("enemy ahead");
				return true;
			} 
		}

		Debug.Log ("no enemy ahead");
		return false;
	}
}

