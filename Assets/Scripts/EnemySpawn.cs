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
		GameObject current_enemy = null;
		time += Time.deltaTime * Time.timeScale;
		if ((time) >= SpawnTimer){
			current_enemy = Object.Instantiate(enemy);
			this.time = 0;

		}
		if (current_enemy != null){
			Enemy enemy_stats = current_enemy.GetComponent<Enemy>();
			LeanTween.moveSpline(current_enemy, mg.ltpath, mg.ltpath.distance * Time.timeScale/enemy_stats.speed);

			CreatePath.enemies.Add(current_enemy);
			current_enemy = null;

		}


	}
}
