using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public float spawnTime = 3.0f;
	float timer;

	// Use this for initialization
	void Start () {

		timer = spawnTime;

	}
	
	// Update is called once per frame
	void Update () {
	
		timer += Time.deltaTime; 

	}

	public bool SpawnOn(){

		return timer > spawnTime;

	}

	public void SpawnReset(){

		timer = 0f;
		Debug.Log ("spawn reset" + name);
	}

	public void OnDrawGizmos(){
		Gizmos.DrawWireCube(transform.position, new Vector3 (0.5f, 0.5f));
	}

}
