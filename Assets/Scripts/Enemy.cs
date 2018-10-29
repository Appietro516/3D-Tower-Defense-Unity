using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	public int health;
	public int speed;
	public int damage;
	public int value;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (this.isDead()){
			PlayerBehaviors.money += this.value;
			this.teardown();
		}

	}

	void OnTriggerEnter(Collider col){
		Core core = (Core)col.gameObject.GetComponent("Core");
		if (core != null){
			core.changeHealth(damage*-1);
			this.teardown();
		}

	}

	public void take_damage(int deltaHealth){
		this.health -= deltaHealth;
	}

	private bool isDead(){
		return health <= 0;
	}

	private void teardown(){
		CreatePath.enemies.Remove(this.gameObject);
		Destroy(this.gameObject);
	}
}
