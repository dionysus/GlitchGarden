using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {


	public static GameObject selectedDefender;
	public GameObject defenderPrefab;

	private SpriteRenderer buttonSprite;
	private Button[] buttonArray;

	// Use this for initialization
	void Start () {

		buttonSprite = GetComponentInChildren<SpriteRenderer>();
		//buttonSprite.color = Color.black;
		buttonArray = GameObject.FindObjectsOfType<Button> ();
		AllButtonsUpdate ();
	}

	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown (){

		AllButtonsUpdate ();

		int defenderCost = defenderPrefab.GetComponent<Defender> ().cloudCost;

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
