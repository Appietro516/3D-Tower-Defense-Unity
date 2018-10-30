using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour {
	void Update () {
		if(this.isDead()){
			PlayerBehaviors.gamover = true;
		}

	}

	public void changeHealth(int delta){
		PlayerBehaviors.health += delta;
	}


	private bool isDead(){
		return PlayerBehaviors.health <= 0;
	}


}
