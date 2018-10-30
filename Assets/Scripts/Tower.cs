using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

	public int range;
	public int damage;
	public float reload_time;
	public int upgradeCost = 25;

	public int price;

	//shouldve used enum
	public bool low_health_targets = true;
	public bool speed_targets = false;

	private bool loaded = true;
	private float since_fired = 0;

	private LineRenderer line;
	private Light pointlight;

	private Color init_color;

	// Use this for initialization
	void Start () {
		init_color = gameObject.GetComponent<Renderer>().material.color;
		line = this.gameObject.GetComponent<LineRenderer>();
		pointlight = this.gameObject.GetComponent<Light>();

	}

	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown("Toggle")){
		  low_health_targets = true;
		  speed_targets = false;
		}
		if (Input.GetButtonDown("Toggle2")){
		  low_health_targets = false;
		  speed_targets = false;
		}

		if (Input.GetButtonDown("Fast")){
		  speed_targets = true;
		}

		Vector3[] points = new Vector3[2];

		GameObject enemy = getTarget();
		if(enemy){
			points[0] = Vector3.Scale(this.gameObject.transform.position, new Vector3(1,2f,1));
			points[1] = enemy.transform.position;
			pointlight.enabled = true;
			line.SetPositions(points);
		}
		else{
			pointlight.enabled = false;
			line.SetPositions(points);
		}

		if(loaded){
			if(enemy != null && inRange(enemy)){
				loaded = false;
				Enemy enemy_stats = enemy.GetComponent<Enemy>();
				enemy_stats.health-= damage;
				since_fired = 0;
				return;

			}
		}
		else{
			since_fired += Time.deltaTime;
			if(since_fired >= reload_time){
				loaded = true;
			}
		}



		//target = null;

	}

	bool inRange(GameObject other){
		Vector3 thisPos = this.gameObject.transform.position;
		Vector3 otherPos = other.transform.position;

		return (Vector3.Distance(thisPos, otherPos) <= range);


	}

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
