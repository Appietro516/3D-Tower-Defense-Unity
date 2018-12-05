using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour {

	public TextMeshProUGUI scores;
	public TextMeshProUGUI towerText;

	public TowerSelector ts;

	// Use this for initialization
	void Start () {

	}

	void Update () {
		UpdateScores();
		UpdateTower();
   	}

	void UpdateScores(){
		this.scores.SetText("Money: " + PlayerBehaviors.money + "\n" + "Health: " + PlayerBehaviors.health +"\n" + "Wave: " + PlayerBehaviors.wave + "\n"+ "Mobs Defeated: " + PlayerBehaviors.enemiesKilled + "\n");
	}

	void UpdateTower(){
		string nameStr = ts.currentComp.nameStr;
		string descrStr = ts.currentComp.descrStr;
		towerText.SetText("<Q Currently Selected Tower E> \n\n" + nameStr + "\n" + descrStr);
	}


}
