using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour {


	public static GameObject selectedDefender;
	public GameObject defenderPrefab;

	private Text text;
	private SpriteRenderer buttonSprite;
	private Button[] buttonArray;
	private int defenderCost;

	// Use this for initialization
	void Start () {

		buttonSprite = GetComponentInChildren<SpriteRenderer>();

		defenderCost = defenderPrefab.GetComponent<Defender> ().cloudCost;
		GetComponentInChildren<Text> ().text = defenderCost.ToString ();

		buttonArray = GameObject.FindObjectsOfType<Button> ();
		AllButtonsUpdate ();
	}

	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown (){

		AllButtonsUpdate ();

		if (defenderCost < CloudDisplay.cloudCount) {
			buttonSprite.color = Color.white;
		} else {
			buttonSprite.color = Color.black;
		}

		selectedDefender = defenderPrefab;

	}

	public void AllButtonsUpdate (){

		foreach (Button thisButton in buttonArray) {

			int defenderCost = thisButton.defenderPrefab.GetComponent<Defender> ().cloudCost;

			if (defenderCost < CloudDisplay.cloudCount) {
				thisButton.GetComponentInChildren<SpriteRenderer> ().color = Color.grey;
			} else {
				thisButton.GetComponentInChildren<SpriteRenderer> ().color = Color.black;
			}
		}
	}
}
