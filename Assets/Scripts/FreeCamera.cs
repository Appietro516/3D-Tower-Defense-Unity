using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeCamera : MonoBehaviour {

	private Vector3 initpos;

	void Start () {
		initpos = this.gameObject.transform.position;

	}

	// Update is called once per frame
	void Update () {
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");
		float scroll = Input.GetAxis("Scroll");

		if (horizontal != 0){
			this.gameObject.transform.position += new Vector3(horizontal,0,0);
		}


		if (vertical != 0){
			this.gameObject.transform.position += new Vector3(0,0,vertical);
		}

		if (scroll != 0){
			this.gameObject.transform.position += new Vector3(0,-1*scroll,0);
		}

		if (Input.GetButtonDown("Reset")){
			this.gameObject.transform.position = initpos;
		}

	}
}
