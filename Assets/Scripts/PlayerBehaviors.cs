using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviors : MonoBehaviour {

	[SerializeField] public static int money = 5;
	[SerializeField] public static int health = 100;
	[SerializeField] public static int score;

	public static bool paused = false;

	public GameObject pausetext;

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

	}
}
