using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

	public int range;
	public int damage;
	public float reload_time;

	public int price;

	private bool loaded = true;
	private float since_fired = 0;


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if(loaded){
			foreach (GameObject enemy in CreatePath.enemies){
				if(inRange(enemy)){
					loaded = false;
					print(enemy);
					Enemy enemy_stats = enemy.GetComponent<Enemy>();
					enemy_stats.health-= damage;
					since_fired = 0;
					return;
				}
			}
		}

		else{
			since_fired += Time.deltaTime;
			if(since_fired >= reload_time){
				loaded = true;
			}
		}



	}

	bool inRange(GameObject other){
		Vector3 thisPos = this.gameObject.transform.position;
		Vector3 otherPos = other.transform.position;

		return (Vector3.Distance(thisPos, otherPos) <= range);


	}

}
