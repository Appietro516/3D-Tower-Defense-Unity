using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DentedPixel;

using UnityEngine.SceneManagement;

public class SplineTest : MonoBehaviour {
	public GameObject lt;
	public CreatePath mg;
	public int speed;

	private int life = 3;

	public TileMap _tileMap;

	void Start() {
		LeanTween.moveSpline(lt, mg.ltpath, life);
		this.gameObject.GetComponent<TrailRenderer>().enabled=true;
		Invoke("destroythis", life);
	}

	void Update(){
		float x = _tileMap.PostoI(this.transform.position.x );
		float z = _tileMap.PostoI(this.transform.position.z);

		//print("x: " + (int)x);
		//print("z: " + (int)z);


		_tileMap.buildable[(int)x , (int)z] = false;


	}

	void destroythis(){
		Destroy(this);
	}

}
