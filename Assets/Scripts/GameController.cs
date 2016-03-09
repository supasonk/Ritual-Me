﻿using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public static GameController instance;

	GameObject circleBar, gaugeBar;
	bool isRitual;
	float ritualCounter;

	void Awake () {
		instance = this;
	}

	// Use this for initialization
	void Start () {
		circleBar = GameObject.Find ("Element");
		gaugeBar = GameObject.Find ("Gauge");
		hideGauge ();
	}

	void ritualPhaseCounter(){
		if (isRitual) {
			ritualCounter += Time.deltaTime;

			if (ritualCounter >= 10) {
				Debug.Log ("Ritual END!");
				stopRitualPhase ();
				ritualCounter = 0;
//				RitualController.instance.stopRitual();
			}
		}
	} 


	public void startRitualPhase () {
		hideCircleBar ();
		unhideGauge ();
		isRitual = true;
	}

	public void stopRitualPhase () {
		unhideCircleBar ();
		hideGauge ();
		isRitual = false;
	}

	void clearElement () {
		GameObject[] temp = GameObject.FindGameObjectsWithTag("Element");
		foreach(GameObject i in temp){
			Destroy (i);	
		}
	}
		


	void hideCircleBar () {
		clearElement ();
		circleBar.SetActive (false);
	}
		
	void hideGauge () {
		clearElement ();
		gaugeBar.SetActive (false);
	}

	void unhideCircleBar () { circleBar.SetActive (true); }
	void unhideGauge () { gaugeBar.SetActive (true); }

		

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.C)) { clearElement (); }

		ritualPhaseCounter ();

//		if (Input.GetKeyDown (KeyCode.Q)) { hideCircleBar (); }
//		if (Input.GetKeyDown (KeyCode.W)) { unhideCircleBar (); }
	}
}
