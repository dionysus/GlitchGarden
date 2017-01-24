using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloudDisplay : MonoBehaviour {


	public enum Status {SUCCESS, FAILURE};
	public static int cloudCount = 100;

	private Button button;

	private Text text;

	// Use this for initialization
	void Start () {

		button = FindObjectOfType<Button>();
		text = GetComponent<Text> ();
		updateCloudCount ();

	}

	public void AddClouds (int amount){
		Debug.Log (amount + " stars added to display");

		cloudCount += amount;
		updateCloudCount ();
		button.AllButtonsUpdate ();

	}

	public Status UseStars (int amount){

		if (cloudCount >= amount) {
			cloudCount -= amount;
			updateCloudCount ();
			button.AllButtonsUpdate ();
			return Status.SUCCESS;
		}
			return Status.FAILURE;
	}

	private void updateCloudCount () {
		text.text = cloudCount.ToString();
	
		if (cloudCount <= 0) {
			text.color = Color.yellow;
		} else {
			text.color = Color.magenta;
		}
	}

}
