using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {
	float SpawnTimer =  2f;
	float time  = 0;

	public CreatePath mg;
	public GameObject enemy;
	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if ((time) >= SpawnTimer){
			GameObject current_enemy = Object.Instantiate(enemy);
			LeanTween.moveSpline(current_enemy, mg.ltpath, mg.ltpath.distance/10); // animate
		}


	}
}
