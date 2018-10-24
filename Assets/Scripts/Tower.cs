using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

	public int range;
	public int damage;

	public Enemy target;


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		foreach (GameObject enemy in CreatePath.enemies){
			if(inRange(enemy)){
				print("FIRE");
				Enemy enemy_stats = enemy.GetComponent<Enemy>();
				enemy_stats.health--;
				return;
			}
		}

	}

	bool inRange(GameObject other){
		Vector3 thisPos = this.gameObject.transform.position;
		Vector3 otherPos = other.transform.position;

		return (Vector3.Distance(thisPos, otherPos) <= range);


	}

}
