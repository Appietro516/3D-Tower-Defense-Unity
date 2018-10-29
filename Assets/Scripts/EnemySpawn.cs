using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {
	float SpawnTimer =  2f;
	float time  = 0;

	float wave_start = 5f;
	float wavetime = 0;

	public CreatePath mg;
	public GameObject enemy;

	public GameObject waveNotifier;


	public int start_points;

	private bool waveOn = false;
	private int points;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		points -= 10;
		if (!waveOn){
			waveNotifier.SetActive(true);
			wavetime += Time.deltaTime * Time.timeScale;
			if ((wavetime) >= wave_start){
				waveOn = true;
				waveNotifier.SetActive(false);
				points = start_points * PlayerBehaviors.wave;
				wavetime = 0;
			}
		}

		else{
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

			if(points >= 0){
				waveOn = false;
			}
		}

	}


}
