using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	public int health;
	public int speed;
	public int damage;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (this.isDead()){
			Destroy(this.gameObject);
			CreatePath.enemies.Remove(this.gameObject);
		}

	}

	void OnTriggerEnter(Collider col){
		Core core = (Core)col.gameObject.GetComponent("Core");
		if (core != null){
			core.health -= damage;
			Destroy(this.gameObject);
			CreatePath.enemies.Remove(this.gameObject);
		}

	}

	public void take_damage(int deltaHealth){
		this.health -= deltaHealth;
	}

	private bool isDead(){
		return health <= 0;
	}
}
