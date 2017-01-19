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

	void Update () {

	}

	void OnEnable(){SceneManager.sceneLoaded += OnLevelFinishedLoading;}
	void OnDisable(){SceneManager.sceneLoaded -= OnLevelFinishedLoading;}

	void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode){

		int levelIndex = scene.buildIndex;
		AudioClip thisLevelMusic = levelMusicChangeArray[levelIndex];

		if (thisLevelMusic) { //if music is attached
			audioSource.clip = thisLevelMusic;
			audioSource.loop = true;
			audioSource.Play();
		}
	}

	public void SetVolume (float volume){

		audioSource.volume = volume;

	}

}
