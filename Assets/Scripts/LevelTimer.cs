using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTimer : MonoBehaviour {

	public LevelManager levelManager;
	public bool winBegan = false;

	private AudioClip audioClip;
	private AudioSource audioSource;
	private Slider slider;
	private GameObject winLabel;


	private float levelLength = 100f;

	// Use this for initialization
	void Start () {

		audioSource = GetComponent<AudioSource>();
		slider = GetComponent<Slider> ();
		slider.value = 0;
		slider.maxValue = levelLength;

		FindWinLabel ();
	}
	
	// Update is called once per frame
	void Update () {

		slider.value += Time.deltaTime;

		if (slider.value >= slider.maxValue && !winBegan) {

			Debug.Log ("you have won");
			audioSource.Play();
			winLabel.SetActive(true);
			Invoke ("LoadWinScene", audioSource.clip.length);
			winBegan = true;

		}

	}
		
	void FindWinLabel (){

		winLabel = GameObject.Find ("winText");

		if (!winLabel) {
			Debug.LogWarning ("TODO: Create Win Label");
		}

		winLabel.SetActive (false);

	}

	void LoadWinScene () {
	
		levelManager.LoadLevel ("03A Win");

	}
	
}
