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

	//state tracking
	private bool loaded = true;
	private float since_fired = 0;
	private bool low_health_targets = true;
	private bool speed_targets = false;

	//display stuff
	private LineRenderer line;
	private Light pointlight;
	private Color init_color;


	void Start () {
		init_color = gameObject.GetComponent<Renderer>().material.color;
		line = this.gameObject.GetComponent<LineRenderer>();
		pointlight = this.gameObject.GetComponent<Light>();
	}

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

		if(loaded){
			loaded = fire();

		}
		else{
			since_fired += Time.deltaTime;
			if(since_fired >= reload_time){
				loaded = true;
			}
		}

		miscUpdate();

	}


	abstract void OnMouseOver();

	abstract void OnMouseExit();

	abstract void OnMouseDown();

	abstract bool fire();

	//abstract GameObject getTarget();

	abstract void miscUpdate();



	bool inRange(GameObject other){
		Vector3 thisPos = this.gameObject.transform.position;
		Vector3 otherPos = other.transform.position;

		return (Vector3.Distance(thisPos, otherPos) <= range);
	}



}
