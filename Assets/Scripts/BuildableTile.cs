using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildableTile : MonoBehaviour {
	public bool buildable;
	public GameObject tower; //tower selector

	private Color init_color;

	void Start(){
		init_color = gameObject.GetComponent<Renderer>().material.color;
		buildable = true;
	}

	void Update(){
		if (!buildable){
			this.gameObject.GetComponent<Renderer>().material.color = Color.blue;
			this.gameObject.GetComponent<MeshCollider>().enabled = false;
		}
	}

	void OnMouseOver(){
		if (PlayerBehaviors.money >= tower.GetComponent<Tower>().price){
			gameObject.GetComponent<Renderer>().material.color = Color.green;
		}
		else{
			gameObject.GetComponent<Renderer>().material.color = Color.red;
		}
	}

	void OnMouseExit(){
		gameObject.GetComponent<Renderer>().material.color = init_color;
	}

	void OnMouseDown(){
		if (buildable){
			if (PlayerBehaviors.money >= tower.GetComponent<Tower>().price){
				GameObject built_tower = Object.Instantiate(tower);
				built_tower.transform.position = new Vector3(this.transform.position.x, 1f, this.transform.position.z);

				PlayerBehaviors.money -= tower.GetComponent<Tower>().price;
			}


		}
	}
}
