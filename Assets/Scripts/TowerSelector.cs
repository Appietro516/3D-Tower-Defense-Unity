using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSelector : MonoBehaviour {

	public AbstractTower[] towers;

	private int selectedTower = 0;


	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("advance")){
			i+=1;
			if (i >= towers.length){
				i = 0;
			}

		}

		elif (Input.GetButtonDown("back")){
			i-=1;
			if (i < 0){
				i = tower.length-1;
			}

		}

	}

	public GameObject getTower(){
		return towers[i];
	}
}
