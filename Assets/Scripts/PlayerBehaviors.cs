using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviors : MonoBehaviour {

	[SerializeField] public static int money = 100;
	[SerializeField] public static int health = 100;
	[SerializeField] public static int wave = 0;

	public static bool paused = false;

	public GameObject pausetext;
	public GameObject controls;
	public GameObject reminder;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Pause")){
		   Time.timeScale = -1*Time.timeScale + 1;
		   paused = !paused;
		   pausetext.SetActive(!pausetext.activeSelf);

	   	}

		if (Input.GetButtonDown("Controls")){
		 	controls.SetActive(!controls.activeSelf);
			reminder.SetActive(!reminder.activeSelf);

	   	}

		if (Input.GetButtonDown("Exit")){
			 Application.Quit();
		}

	}
}
