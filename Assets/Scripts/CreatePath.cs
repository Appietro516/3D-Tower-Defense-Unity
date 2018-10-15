using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using Random=UnityEngine.Random;


public class CreatePath : MonoBehaviour {
	public int map_size;

	public GameObject floor;
	public LTBezierPath ltpath;
	public int segments;

	private Vector3 start = Vector3.zero;
	private Vector3 end = Vector3.zero;

	private Vector3 top_left;
	private Vector3 top_right;
	private Vector3 bot_left;
	private Vector3 bot_right;



	// Use this for initialization
	void Start () {
		top_left = new Vector3(map_size/2, 0, -map_size/2);
		top_right = new Vector3(map_size/2, 0, map_size/2);
		bot_left = new Vector3(-map_size/2, 0, -map_size/2);
		bot_right = new Vector3(-map_size/2, 0, map_size/2);
		for(int i = -1*map_size/2; i < map_size/2 + 1; i++){
			for (int j = -1*map_size/2; j < map_size/2 + 1; j++){
				GameObject thisfloor = Instantiate(floor);
				thisfloor.transform.parent = this.gameObject.transform;
				thisfloor.transform.localPosition = new Vector3(i, 0, j);
			}
		}

		ltpath = generate_bezier();
	}

	// Update is called once per frame
	void Update () {

	}

	private LTBezierPath generate_bezier(){
		start = new Vector3(Random.Range(-1*map_size/2, map_size/2), 0,-1*map_size/2);

		Vector3[] current_path = new Vector3[4+(segments*4)];
		current_path[0] = start;

		Vector3 last_inter = start;
		Vector3 inter = Vector3.zero;
		for(int i = 0; i < this.segments;i++){
			if (last_inter == start){
				inter = generate_random_bounded(-map_size/2 +1, (-map_size/2 +1) + map_size/((segments)));
			}
			else{
				inter = generate_random_bounded(inter.z, inter.z + (map_size/2 - inter.z)/( segments-i));;
			}
			current_path[i*4 + 1] =  generate_random_bounded(last_inter.z, inter.z);
			current_path[i*4 + 2] = current_path[i*4+1];
			current_path[i*4 + 3] = inter;
			current_path[i*4 + 4] = inter;
			last_inter = inter;

		}
		if (segments == 0){
			current_path[1] = generate_random();
			current_path[2] = generate_random();

		}

		end =  new Vector3(Random.Range(-1*map_size/2 , map_size/2), 0,map_size/2);
		current_path[(segments*4)+1] = generate_random_bounded(inter.z, map_size/2-1);
		current_path[(segments*4)+1].x = end.x;
		current_path[(segments*4)+2] = current_path[(segments*4)+1];
		current_path[(segments*4)+3] = end;

		return new LTBezierPath(current_path);


	}

	private Vector3 generate_random(){
		return new Vector3(Random.Range(-1*map_size/2, map_size/2), 0,Random.Range(-1*map_size/2, map_size/2));
	}

	private Vector3 generate_random_bounded(float z_constraint,float z_constraint2){
		return new Vector3(Random.Range(-map_size/2, map_size/2), 0,Random.Range(z_constraint+2, z_constraint2));
	}



}
