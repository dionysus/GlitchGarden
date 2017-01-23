using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour {

	public int cloudCost = 100;

	private CloudDisplay cloudDisplay;

	void Start (){

		cloudDisplay = GameObject.FindObjectOfType<CloudDisplay> ();

	}

	public void AddCloud(int amount){
		cloudDisplay.AddClouds (amount);
	}



}
