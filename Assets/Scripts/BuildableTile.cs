using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildableTile : MonoBehaviour {
	public bool buildable;

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
		print("hi1");
		gameObject.GetComponent<Renderer>().material.color = Color.green;
	}

	void OnMouseExit(){
		print("hi2");
		gameObject.GetComponent<Renderer>().material.color = init_color;
	}
}
