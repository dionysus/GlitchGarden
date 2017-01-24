using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LosePanel : MonoBehaviour {


	public LevelManager levelManager;

	private Animator animator;



	// Use this for initialization
	void Start () {
	
		//Load reference scripts
		animator = GetComponent<Animator>();

	}


	public void LoseAnimation (){
		animator.SetTrigger ("LoseGame");

	}
		
	public void LoseLevel (){

		levelManager.LoadLevel ("03B Lose");

		Debug.Log ("Move to Lose");

	}

}
