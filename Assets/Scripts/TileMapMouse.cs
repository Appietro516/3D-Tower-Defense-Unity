using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TileMap))]
public class TileMapMouse : MonoBehaviour {

	TileMap _tileMap;

	Vector3 currentTileCoord;

	public Transform selectionCube;
	public GameObject tower;

	private bool[,] buildable;

	void Start() {
		_tileMap = GetComponent<TileMap>();

		selectionCube.position = _tileMap.CenterPosition(selectionCube.position);
		selectionCube.localScale = new Vector3(_tileMap.tileSize/10, 1, _tileMap.tileSize/10);

		buildable = new bool[_tileMap.size_x, _tileMap.size_z];

		for (int i = 0; i < _tileMap.size_x; i++){
			for (int j = 0; j < _tileMap.size_z; j++){
				buildable[i, j] = true;

			}
		}
	}

	// Update is called once per frame
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
		RaycastHit hitInfo;

		if( GetComponent<Collider>().Raycast( ray, out hitInfo, Mathf.Infinity ) ) {
			int x = Mathf.FloorToInt( hitInfo.point.x / _tileMap.tileSize);
			int z = Mathf.FloorToInt( hitInfo.point.z / _tileMap.tileSize);
			//Debug.Log ("Tile: " + x + ", " + z);

			currentTileCoord.x = x;
			currentTileCoord.y = .1f;
			currentTileCoord.z = z;


			selectionCube.transform.position = _tileMap.CenterPosition(currentTileCoord*_tileMap.tileSize);

			MouseOverTile();
		}
		else {
			// Hide selection cube?
		}

		if(Input.GetMouseButtonDown(0)) {
			bool buildableBool = buildable[(int)currentTileCoord.x +12, (int)currentTileCoord.z +12];
			print(currentTileCoord);
			//bool buildableBool = true;


			if (!PlayerBehaviors.paused){
				if (buildableBool){
					if (PlayerBehaviors.money >= tower.GetComponent<Tower>().price){
						GameObject built_tower = Object.Instantiate(tower);
						built_tower.transform.position = new Vector3(selectionCube.transform.position.x, 1f, selectionCube.transform.position.z);

						PlayerBehaviors.money -= tower.GetComponent<Tower>().price;
					}


				}
			}
		}
	}

	public void MouseOverTile(){
		bool buildableBool = buildable[(int)currentTileCoord.x +12, (int)currentTileCoord.z +12];

		//bool buildableBool = true;

		if (PlayerBehaviors.money >= tower.GetComponent<Tower>().price && !PlayerBehaviors.paused && buildableBool){
			selectionCube.gameObject.GetComponent<Renderer>().material.color = Color.green;

		}
		else{
			selectionCube.gameObject.GetComponent<Renderer>().material.color = Color.red;
		}

	}

}
