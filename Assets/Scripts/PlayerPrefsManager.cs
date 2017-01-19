using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// THIS IS A WRAPPER TO MANAGE INPUT FROM SCRIPTS TO PLAYERPREFS
public class PlayerPrefsManager : MonoBehaviour {

	const string MASTER_VOLUME_KEY = "master_volume";
	const string DIFF_KEY = "difficulty";
	const string LEVEL_KEY = "level_unlocked_";
		// level_unlocked_#


// VOLUME

	public static void SetMasterVolume (float volume){
		if (volume > 0f && volume < 1f) {
			PlayerPrefs.SetFloat (MASTER_VOLUME_KEY, volume);
		} else {
			Debug.LogError ("MasterVolume out of range");
		}
	}

	public static float GetMasterVolume () {

		return PlayerPrefs.GetFloat (MASTER_VOLUME_KEY);

	}

// LEVEL UNLOCKED

	public static void UnlockLevel (int level) {

		if (level <= SceneManager.sceneCountInBuildSettings - 1) { //if level is within the the build order

			PlayerPrefs.SetInt (LEVEL_KEY + level.ToString (), 1); //use 1 for true

		} else { Debug.LogError ("Unlock level not in build order"); }
	}

	public static bool IsLevelUnlocked (int level){

		int levelValue = PlayerPrefs.GetInt (LEVEL_KEY + level.ToString ());

		bool isLevelUnlocked = (levelValue == 1); // Is LEVEL_KEY = 1 (true / unlocked)?

		if (level <= SceneManager.sceneCountInBuildSettings - 1) { //if level is within build order

			return isLevelUnlocked;  // true or false

		} else { 
			
			Debug.LogError ("Level queried not in build order"); 
			return false;
		}
	}

// DIFFICULTY

	public static void SetDifficulty (float difficulty){

		if (difficulty >= 1f && difficulty <= 3f) {
			
			PlayerPrefs.SetFloat (DIFF_KEY, difficulty);

		} else {Debug.LogError ("Difficulty set out of range"); }
	
	}

	public static float GetDifficulty (){

		return PlayerPrefs.GetFloat (DIFF_KEY);

	}
		
// END

}
