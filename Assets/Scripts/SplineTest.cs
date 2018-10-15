using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DentedPixel;

using UnityEngine.SceneManagement;

public class SplineTest : MonoBehaviour {
	public GameObject lt;
	public CreatePath mg;
	public int speed;

	void Start() {
		LeanTween.move(lt, mg.ltpath, mg.ltpath.length/speed); // animate
		this.gameObject.GetComponent<TrailRenderer>().enabled=true;



	}

	void OnTriggerEnter(Collider other){
		other.GetComponent<Renderer>().material.color = Color.blue;
	}
}
