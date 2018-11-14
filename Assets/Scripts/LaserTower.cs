using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTower: AbstractTower {

	//fire
	// GameObject enemy = getTarget();
	// if(enemy != null && inRange(enemy)){
	// 	loaded = false;
	// 	Enemy enemy_stats = enemy.GetComponent<Enemy>();
	// 	enemy_stats.health-= damage;
	// 	since_fired = 0;
	// 	return;
	//
	// }

	//miscUpdate
	// Vector3[] points = new Vector3[2];
	// if(enemy){
	// 	points[0] = Vector3.Scale(this.gameObject.transform.position, new Vector3(1,2f,1));
	// 	points[1] = enemy.transform.position;
	// 	pointlight.enabled = true;
	// 	line.SetPositions(points);
	// }
	// else{
	// 	pointlight.enabled = false;
	// 	line.SetPositions(points);
	// }

	private GameObject getTarget(){
		GameObject target = null;

		foreach(GameObject enemy in CreatePath.enemies){
			if (inRange(enemy)){
				if (target == null){
					target = enemy;
					continue;
				}

				Enemy enemy_stats = enemy.GetComponent<Enemy>();
				Enemy target_stats = target.GetComponent<Enemy>();

				if(!speed_targets){
					if (low_health_targets){
						if(enemy_stats.health < target_stats.health){
							target = enemy;
						}
					}
					else{
						if(enemy_stats.health > target_stats.health){
							target = enemy;
						}
					}
				}
				else{
					if(enemy_stats.speed > target_stats.speed){
						target = enemy;
					}
				}
			}

		}
	return target;
	}


	void OnMouseOver(){
		if (PlayerBehaviors.money >= upgradeCost){
			gameObject.GetComponent<Renderer>().material.color = Color.green;
		}
		else{
			gameObject.GetComponent<Renderer>().material.color = init_color;
		}
	}

	void OnMouseExit(){
		gameObject.GetComponent<Renderer>().material.color = init_color;
	}

	void OnMouseDown(){
		if (!PlayerBehaviors.paused){
			if (PlayerBehaviors.money >= upgradeCost){
				range += 1;
				PlayerBehaviors.money -= upgradeCost;
			}
		}
	}


}
