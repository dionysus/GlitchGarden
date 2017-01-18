using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {

	public AudioClip [] levelMusicChangeArray;

	private AudioSource audioSource;

	void Awake () {

		DontDestroyOnLoad (gameObject);
		audioSource = GetComponent<AudioSource> ();

	}

	void Start () {



	}

	void OnEnable()
	{
		//Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
		SceneManager.sceneLoaded += OnLevelFinishedLoading;
	}

	void OnDisable()
	{
		//Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled. 
		//Remember to always have an unsubscription for every delegate you subscribe to!
		SceneManager.sceneLoaded -= OnLevelFinishedLoading;
	}

	void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
	{
		//Debug.Log(scene.buildIndex);

		int levelIndex = scene.buildIndex;
		AudioClip thisLevelMusic = levelMusicChangeArray[levelIndex];

		if (thisLevelMusic) { //if music is attached
			audioSource.clip = thisLevelMusic;
			audioSource.loop = true;
			audioSource.Play();
		}


	}

}
