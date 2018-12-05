using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inspector : MonoBehaviour {

	public TextMeshProUGUI output;
	private Inspectable selected;


	// Update is called once per frame
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
		RaycastHit hit;

		if(Physics.Raycast( ray, out hit, Mathf.Infinity ) ) {
			Inspectable t =hit.transform.gameObject.GetComponent<Inspectable>();
			if (t != null){
				output.SetText(t.getData());
				selected = t;
			}

		}

		if(Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(0)){
			selected = null;
		}

		if(selected == null){
			output.SetText("");
		}
	}
}
