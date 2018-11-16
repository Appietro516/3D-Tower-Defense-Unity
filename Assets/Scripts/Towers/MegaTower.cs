using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegaTower : AbstractTower {

	GameObject targetedEnemy = null;

	//display stuff for laser tower
	protected LineRenderer line;
	protected Light pointlight;

	public override void Start () {
		base.Start();
		line = this.gameObject.GetComponent<LineRenderer>();
		pointlight = this.gameObject.GetComponent<Light>();
	}

	protected override bool fire(){
		if(targetedEnemy != null && inRange(targetedEnemy)){
			Enemy enemy_stats = targetedEnemy.GetComponent<Enemy>();
			enemy_stats.health-= enemy_stats.health;
			since_fired = 0;
			return true;

		}

		this.targetedEnemy = getTarget();
		return false;
	}

	protected override void miscUpdate(){
		Vector3[] points = new Vector3[2];
		if(targetedEnemy){
			points[0] = Vector3.Scale(this.gameObject.transform.position, new Vector3(1,2f,1));
			points[1] = targetedEnemy.transform.position;
			pointlight.enabled = true;
			line.SetPositions(points);
		}
		else{
			pointlight.enabled = false;
			line.SetPositions(points);
		}
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
