using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour {

	public Slider volumeSlider;
	public Slider difficultySlider;
	public LevelManager levelManager;

	private MusicManager musicManager;

	void Start () {

		musicManager = GameObject.FindObjectOfType<MusicManager> ();

		UpdateSliders ();

	}

	void Update (){

		if (musicManager) {
			musicManager.SetVolume (volumeSlider.value);
		}
	}

	public void SaveSettings (){

		PlayerPrefsManager.SetMasterVolume (volumeSlider.value);
		PlayerPrefsManager.SetDifficulty (difficultySlider.value);

		print ("volume: " + PlayerPrefsManager.GetMasterVolume ());
		print ("difficulty: " + PlayerPrefsManager.GetDifficulty ());

	}

	public void SetDefault (){

		PlayerPrefsManager.SetMasterVolume (0.5f);
		PlayerPrefsManager.SetDifficulty (1);
		UpdateSliders ();

	}

	public void UpdateSliders (){
		
		volumeSlider.value = PlayerPrefsManager.GetMasterVolume ();
		difficultySlider.value = PlayerPrefsManager.GetDifficulty ();
	}

}
