using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	public int health;
	public int speed;
	public int damage;
	public int value;
	public GameObject ragdoll;


	// Update is called once per frame
	void Update () {
		if (this.isDead()){
			PlayerBehaviors.money += this.value;
			PlayerBehaviors.enemiesKilled += 1;
			GameObject current_ragdoll = Instantiate(ragdoll, this.gameObject.transform.position, Quaternion.identity);
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


	private bool isDead(){
		return health <= 0;
	}

	private void teardown(){
		CreatePath.enemies.Remove(this.gameObject);
		Destroy(this.gameObject);
	}
}
