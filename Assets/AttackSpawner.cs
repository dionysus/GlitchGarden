using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpawner : MonoBehaviour {

	public GameObject [] attackerTypesArray;
	public float spawnStartTime, spawnRepeatTime;


	private GameObject attackerParent, spawner;

	void Start (){

		// find/create projectiles folder for spawned projectiles
		attackerParent = GameObject.Find ("Attackers");

		if (!attackerParent) {
			attackerParent = new GameObject("Attackers");
		}

		//InvokeRepeating("SpawnType", 2.0f, Random.Range(4f, 8f));


	}

	void Update () {

		foreach (GameObject thisAttacker in attackerTypesArray) {

			if (isTimeToSpawn (thisAttacker)) {

				Spawn (thisAttacker);

			}
		}
	}


	bool isTimeToSpawn (GameObject attackerGameObject) {

		Attacker attacker = attackerGameObject.GetComponent<Attacker>();

		float meanSpawnDelay = attacker.seenEverySeconds;
		float spawnsPerSecond = 1 / meanSpawnDelay;

		float spawnBuffer;

		bool spawnOff = false;

		/*
		spawnBuffer -= Time.deltaTime;

		if (spawnBuffer >= 0) {
			spawnOff = true;
		} else {
			spawnOff = false;
		}
		*/

		if (Time.deltaTime > meanSpawnDelay) { 

			Debug.LogWarning ("Spawn rate capped by frame rate");
		}

		// spawnsPersecond = 1/x
		// increases gradually with time

		float threshold = spawnsPerSecond * Time.deltaTime / 5;

		// Random.value generates random b/w 0 to 1
		// when random.value is less than the increasing delta.time

		if (Random.value < threshold) {
			return true;
			//spawnBuffer = 2;
		} else {
			return false;
		}

		return true;
	}


	public void OnDrawGizmos(){
		Gizmos.DrawWireCube(transform.position, new Vector3 (0.5f, 0.5f));
	}

	void SpawnType (){

		float randomMax = attackerTypesArray.Length - 1;
		float randomFloat = Random.Range (0f, randomMax);
		int randomIndex = (int) Mathf.Round(randomFloat);
		GameObject randomAttacker = attackerTypesArray [randomIndex];
		Spawn (randomAttacker);

		Debug.Log (randomAttacker.name);
	}


	void Spawn (GameObject myGameObject){

		Object.Instantiate (myGameObject, transform.position, Quaternion.identity, attackerParent.transform);

	}

}
