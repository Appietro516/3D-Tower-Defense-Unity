using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {
	public RectTransform healthBar;
	public Enemy enemy;



	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		healthBar.sizeDelta = new Vector2(enemy.health, healthBar.sizeDelta.y);
	}
}
