using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour {
	//TODO create a superclass for a healthful object.
	public int health;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if(this.isDead()){
			print("GAME OVER");
		}

	}


	private bool isDead(){
		return health <= 0;
	}


}
