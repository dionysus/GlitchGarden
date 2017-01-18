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
		Debug.Log (musicManager);

		UpdateSliders ();

	}

	public void SaveSettings (){

		PlayerPrefsManager.SetMasterVolume (volumeSlider.value);
		PlayerPrefsManager.SetDifficulty (difficultySlider.value);

		print ("volume: " + PlayerPrefsManager.GetMasterVolume ());
		print ("difficulty: " + PlayerPrefsManager.GetDifficulty ());

	}

	public void DefaultSettings (){

		PlayerPrefsManager.SetMasterVolume (0.5f);
		PlayerPrefsManager.SetDifficulty (0.5f);
		UpdateSliders ();

	}

	public void UpdateSliders (){
		volumeSlider.value = PlayerPrefsManager.GetMasterVolume ();
		difficultySlider.value = PlayerPrefsManager.GetDifficulty ();
	}

}
