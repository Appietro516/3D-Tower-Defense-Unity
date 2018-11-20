using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoeTower : AbstractTower {

	// Use this for initialization
	public override void Start () {
		//Debug.Log("start ran!");
		base.Start();
	}

	protected override bool fire(){
		foreach(GameObject targetedEnemy in CreatePath.enemies){
			if (inRange(targetedEnemy)){
				Enemy enemy_stats = targetedEnemy.GetComponent<Enemy>();
				enemy_stats.health-= damage;
			}
		}
		since_fired = 0;
		return true;
	}

	protected override void miscUpdate(){

	}


}
