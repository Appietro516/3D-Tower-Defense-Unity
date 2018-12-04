using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviors : MonoBehaviour {

	[SerializeField] public static int money = 125;
	[SerializeField] public static int health = 50;
	[SerializeField] public static int wave = 0;
	[SerializeField] public static int enemiesKilled = 0;

	public static bool paused = false;
	public static bool gamover = false;

	public GameObject pausetext;
	public GameObject controls;
	public GameObject exits;
	public AudioSource musicplayer;



	// Update is called once per frame
	void Update () {
		if (!gamover){
			if (Input.GetButtonDown("Pause")){
			   Time.timeScale = -1*Time.timeScale + 1;
			   paused = !paused;
			   pausetext.SetActive(!pausetext.activeSelf);

		   	}
		}

		if (Input.GetButtonDown("Controls")){
		 	controls.SetActive(!controls.activeSelf);
	   	}

		if (Input.GetButtonDown("Exit")){
			 Application.Quit();
		}

		if (Input.GetButtonDown("Mute")){
			 musicplayer.mute = !musicplayer.mute;
		}

		if(gamover){
			Invoke("Gameover",2);
		}

	}

	private void Gameover(){
		Time.timeScale = 0;
		exits.SetActive(true);
	}
}
