using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//the bank tower does not need to update itself, so most  methods are empty.
public class Bomb : AbstractTower {

	public override void Start () {
		base.Start();
	}

	protected override void miscUpdate(){
		return;
	}

	protected override bool fire(){
		return true;
	}

	void OnMouseDown(){
		Destroy(this.gameObject);
		foreach(GameObject targetedEnemy in CreatePath.enemies){
			if (inRange(targetedEnemy)){
				Enemy enemy_stats = targetedEnemy.GetComponent<Enemy>();
				enemy_stats.health = enemy_stats.health/2;
			}
		}

	}



}
