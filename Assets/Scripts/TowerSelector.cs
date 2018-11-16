using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSelector : MonoBehaviour {

	public GameObject[] towers;

	private int selectedTower = 0;

	void Update () {
		if (Input.GetButtonDown("advance")){
			selectedTower += 1;
			if (selectedTower >= towers.Length){
				selectedTower = 0;
			}
		}

		else if (Input.GetButtonDown("back")){
			selectedTower -= 1;
			if (selectedTower < 0){
				selectedTower = towers.Length - 1;
			}
		}

	}

	public GameObject getTower(){
		return towers[selectedTower];

	}

}
