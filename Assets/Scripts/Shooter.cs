using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

	public GameObject projectileType, projectileSpawn;

	private GameObject projectileParent;


	void Start (){

	// find/create projectiles folder for spawned projectiles
		projectileParent = GameObject.Find ("Projectiles");

		if (!projectileParent) {
			projectileParent = new GameObject("Projectiles");
		}

	}

	private void Fire (){

		GameObject newProjectile = Object.Instantiate (projectileType, projectileSpawn.transform.position, Quaternion.identity, projectileParent.transform);
	
	}
}

