using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

	// Use this for initialization
	void Start () {

		print ("initial volume: " + PlayerPrefsManager.GetMasterVolume ());
		PlayerPrefsManager.SetMasterVolume (0.5f);
		print ("final volume: " + PlayerPrefsManager.GetMasterVolume ());


		print ("Level unlocked: " + PlayerPrefsManager.IsLevelUnlocked (2));
		PlayerPrefsManager.UnlockLevel(2);
		print ("Level unlocked: " + PlayerPrefsManager.IsLevelUnlocked (2));

		print ("initial difficulty: " + PlayerPrefsManager.GetDifficulty ());
		PlayerPrefsManager.SetDifficulty (0.7f);
		print ("final difficulty: " + PlayerPrefsManager.GetDifficulty ());

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
