using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {

	public static int height;
	public Camera myCamera;

	private GameObject defenderParent;
	private CloudDisplay cloudDisplay;

	void Start (){

		// attach references
		cloudDisplay = GameObject.FindObjectOfType<CloudDisplay>();

		// find/create projectiles folder for spawned projectiles
		defenderParent = GameObject.Find ("Defenders");

		if (!defenderParent) {
			defenderParent = new GameObject("Defenders");
		}

	}

	void OnMouseDown () { //add collider to UI for button

		Vector2 rawPos = CalculateWorldPointMouse ();
		Vector2 roundedPos = SnapToGrid (rawPos);

		GameObject selectedDefender = Button.selectedDefender;

		int defenderCost = selectedDefender.GetComponent<Defender> ().cloudCost;

		if (cloudDisplay.UseStars (defenderCost) == CloudDisplay.Status.SUCCESS) { //enum success?
			Object.Instantiate (Button.selectedDefender, roundedPos, Quaternion.identity, defenderParent.transform);
		} else {
			Debug.Log ("Not enough Clouds");
		}
	}

	Vector2 CalculateWorldPointMouse (){
		
		float mouseX = Input.mousePosition.x;
		float mouseY = Input.mousePosition.y;
		float distanceFromCamera = 10f;

		Vector3 cameraScreen = new Vector3 (mouseX, mouseY, distanceFromCamera);
		Vector2 worldPos = myCamera.ScreenToWorldPoint (cameraScreen);

		SnapToGrid (worldPos);

		return worldPos;
	}

	Vector2 SnapToGrid (Vector2 rawWorldPos){

		int snapPosX = Mathf.RoundToInt (rawWorldPos.x);
		int snapPosY = Mathf.RoundToInt (rawWorldPos.y);

		Vector2 snapPos = new Vector2 (snapPosX, snapPosY);

		return snapPos;

	}



}
