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
		gameObject.GetComponent<Renderer>().material.color = Color.green;
	}

	void OnMouseExit(){
		gameObject.GetComponent<Renderer>().material.color = init_color;
	}

	void OnMouseDown(){
		if (buildable){
			GameObject built_tower = Object.Instantiate(tower);
			built_tower.transform.position = this.transform.position;

		}
	}
}
