using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke("SetFrames", 5);
	}
	void Update(){
		//print(1/Time.deltaTime);
	}

	void SetFrames(){
		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = 60;
	}

}
