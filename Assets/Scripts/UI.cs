using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour {

	public TextMeshProUGUI UItext;

	// Use this for initialization
	void Start () {

	}

	void Update () {
		this.UItext.SetText("Money: " + PlayerBehaviors.money + "\n" + "Health: " + PlayerBehaviors.health +"\n" + "Wave: " + PlayerBehaviors.wave + "\n"+ "Mobs Defeated: " + PlayerBehaviors.enemiesKilled + "\n");


   	}


}
