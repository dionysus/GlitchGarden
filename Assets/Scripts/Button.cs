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
		buttonSprite.color = Color.black;
		buttonArray = GameObject.FindObjectsOfType<Button> ();

	}

	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown (){

		foreach (Button thisButton in buttonArray) {
			thisButton.GetComponentInChildren<SpriteRenderer>().color = Color.black;
		}

		buttonSprite.color = Color.white;

		selectedDefender = defenderPrefab;

	}

}
