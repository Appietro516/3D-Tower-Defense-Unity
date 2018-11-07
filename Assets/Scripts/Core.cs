using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour {
	public GameObject core_explosion;

	void Update () {
		if(this.isDead()){
			PlayerBehaviors.gamover = true;
			for(int i = 0; i < 100; i++){
				Object.Instantiate(core_explosion, this.transform.position, Quaternion.identity);
			}
			Destroy(this.gameObject);
		}

	}

	public void changeHealth(int delta){
		PlayerBehaviors.health += delta;
	}


	private bool isDead(){
		return PlayerBehaviors.health <= 0;
	}


}
