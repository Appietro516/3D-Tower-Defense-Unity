using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractTower : MonoBehaviour {
	//dmg stats
	public int range;
	public int damage;
	public float reload_time;

	//money stats
	public int upgradeCost = 25;
	public int price;

	//reloading
	protected bool loaded = true;
	protected float since_fired = 0;

	//TODO:this needs to be moved but im sticking it here for now
	protected bool low_health_targets = true;
	protected bool speed_targets = false;

	//display stuff
	protected Color init_color;


	//GUI info
	public string descrStr;
	public string nameStr;

	public GameObject rangeCircO;
	private Transform rangeCirc;

	public virtual void Start () {
		init_color = gameObject.GetComponent<Renderer>().material.color;
		GameObject instRangeCirc = Instantiate(this.rangeCircO, this.transform.position, Quaternion.identity);

		this.rangeCirc = instRangeCirc.transform;
		
		this.rangeCirc.localScale = new Vector3(rangeCirc.localScale.x*range*2, rangeCirc.localScale.y, rangeCirc.localScale.z*range*2);
		this.rangeCirc.position = new Vector3(this.transform.position.x, .01f, this.transform.position.z);
	}


	public virtual void Update () {
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

		if (reload_time >= 0){
			if(loaded){
				loaded = !fire();

			}
			else{
				since_fired += Time.deltaTime;
				if(since_fired >= reload_time){
					loaded = true;
				}
			}
		}

		miscUpdate();

	}

	//mouse interactions.
	protected void OnMouseOver(){
		if (PlayerBehaviors.money >= upgradeCost){
			gameObject.GetComponent<Renderer>().material.color = Color.green;
		}
		else{
			gameObject.GetComponent<Renderer>().material.color = init_color;
		}
	}

	protected void OnMouseExit(){
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


	//helpful functions
	protected GameObject getTarget(){
		GameObject target = null;

		foreach(GameObject targetedEnemy in CreatePath.enemies){
			if (inRange(targetedEnemy)){
				if (target == null){
					target = targetedEnemy;
					continue;
				}

			 	Enemy enemy_stats = targetedEnemy.GetComponent<Enemy>();
				Enemy target_stats = target.GetComponent<Enemy>();

				if(!speed_targets){
					if (low_health_targets){
						if(enemy_stats.health < target_stats.health){
							target = targetedEnemy;
						}
					}
					else{
						if(enemy_stats.health > target_stats.health){
							target = targetedEnemy;
						}
					}
				}
				else{
					if(enemy_stats.speed > target_stats.speed){
						target = targetedEnemy;
					}
				}
			}

		}
		return target;
	}

	protected bool inRange(GameObject other){
		Vector3 thisPos = this.gameObject.transform.position;
		Vector3 otherPos = other.transform.position;

		return (Vector3.Distance(thisPos, otherPos) <= range);
	}


	//methods to implment
	protected abstract bool fire();

	protected abstract void miscUpdate();


}
