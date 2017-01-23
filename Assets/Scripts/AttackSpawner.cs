using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpawner : MonoBehaviour {

	public GameObject [] attackerTypesArray;
	public GameObject [] spawnPositionsArray;

	private GameObject attackerParent, spawner;

	void Start (){
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

		if (Time.deltaTime > meanSpawnDelay) { 
			Debug.LogWarning ("Spawn rate capped by frame rate");
		}

		// spawnsPersecond = 1/x
		// increases gradually with time

		float threshold = spawnsPerSecond * Time.deltaTime;

		// Random.value generates random b/w 0 to 1
		// when random.value is less than the increasing delta.time

		if (Random.value < threshold) {
			return true;
		} else {
			return false;
		}
	}
		
		
	void Spawn (GameObject myGameObject){

		List<GameObject> activeSpawnsList = new List<GameObject> (); 

		foreach (GameObject attackerLane in spawnPositionsArray) {

			if (attackerLane.GetComponent<Spawner> ().SpawnOn ()) {

				activeSpawnsList.Add (attackerLane);
			}

		}

		if (activeSpawnsList.Count > 0) {

			float randomMax = activeSpawnsList.Count-1;
			float randomFloat = Random.Range (0f, randomMax);
			int randomIndex = (int)Mathf.Round (randomFloat);

			Debug.Log (randomIndex + " / " + activeSpawnsList.Count);

			GameObject selectedLane = activeSpawnsList [randomIndex];

			Object.Instantiate (myGameObject, selectedLane.transform.position, Quaternion.identity, selectedLane.transform);
			selectedLane.GetComponent<Spawner> ().SpawnReset (); // Start lane buffer time
		
		} else {
		
			Debug.Log ("no activeSpawns");
				
		}
	}
}
