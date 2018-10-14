using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DentedPixel;

using UnityEngine.SceneManagement;

public class SplineTest : MonoBehaviour {
	public GameObject lt;
	public int speed;

	void Awake () {
		SceneManager.sceneLoaded += this.callback;
	}

	void callback(Scene scene, LoadSceneMode sceneMode){
		print("got callback");
		LTBezierPath ltPath = new LTBezierPath( new Vector3[] { new Vector3(0f,.5f,0f),new Vector3(-5f,.5f,8f), new Vector3(-5f,.5f,2f), new Vector3(0f,.5f,10f)} );

		LeanTween.move(lt, ltPath, ltPath.length/speed); // animate

	}
}
