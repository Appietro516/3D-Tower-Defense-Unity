using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSelector : MonoBehaviour {

	public GameObject[] towers;
	public AbstractTower currentComp;

	private int selectedTower = 0;

	void Start(){
		currentComp = getTowerComp();
	}

	void Update () {
		if (Input.GetButtonDown("advance")){
			selectedTower += 1;
			if (selectedTower >= towers.Length){
				selectedTower = 0;
			}
			currentComp = getTowerComp();
		}

		else if (Input.GetButtonDown("back")){
			selectedTower -= 1;
			if (selectedTower < 0){
				selectedTower = towers.Length - 1;
			}
			currentComp = getTowerComp();
		}

	}

	public GameObject getTower(){
		return towers[selectedTower];

	}

	private AbstractTower getTowerComp(){
		return this.getTower().GetComponent<AbstractTower>();
	}

}
