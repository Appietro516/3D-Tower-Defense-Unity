using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class LeaderBoard : MonoBehaviour {

	public static int wave;
	public static int enemyDeaths;
	public Button returnButton;

	public Text high_score;

	void Start () {
		Save.loadLeaderBoard();
		
		this.high_score.text = ("Reached wave " + wave + " and defeated " + enemyDeaths + "enemies on" + DateTime.Today.ToString());

		returnButton.onClick.AddListener(Load_First_Level);

	}
	public void Load_First_Level(){
        print("Loading");
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

}
