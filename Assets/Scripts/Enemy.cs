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
		}

	}

	void OnTriggerEnter(Collider col){
		//core = col.GameObject.getComponent("Core");
		//if (core != null){
		//core.health -= 1; //this.damage;
		//}

	}

	void take_damage(int deltaHealth){
		this.health -= deltaHealth;
	}

	private bool isDead(){
		return health <= 0;
	}
}
