using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {
	public RectTransform healthBar;
	public Enemy enemy;

	private float scale;


	// Use this for initialization
	void Start () {
		scale = healthBar.sizeDelta.x/enemy.health;
	}

	// Update is called once per frame
	void Update () {
		healthBar.sizeDelta = new Vector2(enemy.health*scale, healthBar.sizeDelta.y);
	}
}
