using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TileMap))]
public class TileMapMouse : MonoBehaviour {

	TileMap _tileMap;

	Vector3 currentTileCoord;

	public Transform selectionCube;
	public GameObject tower;

	private bool buildable;

	void Start() {
		_tileMap = GetComponent<TileMap>();

		selectionCube.position = _tileMap.CenterPosition(selectionCube.position);
		selectionCube.localScale = new Vector3(_tileMap.tileSize/10, 1, _tileMap.tileSize/10);



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
			//print(currentTileCoord);
			//bool buildableBool = true;


			if (!PlayerBehaviors.paused){
				if (this.buildable){
					if (PlayerBehaviors.money >= tower.GetComponent<AbstractTower>().price){
						GameObject built_tower = Object.Instantiate(tower);
						built_tower.transform.position = new Vector3(selectionCube.transform.position.x, 1f, selectionCube.transform.position.z);

						CreatePath.towers.Add(built_tower);
						PlayerBehaviors.money -= tower.GetComponent<AbstractTower>().price;
					}


				}
			}
		}
	}

	public void MouseOverTile(){
		//print("BUILDING CHECK:" + currentTileCoord.x + "," + currentTileCoord.z);
		buildable = (_tileMap.canBuildOn(currentTileCoord.x + 12, currentTileCoord.z + 12));


		if (PlayerBehaviors.money >= tower.GetComponent<AbstractTower>().price && !PlayerBehaviors.paused && buildable){
			selectionCube.gameObject.GetComponent<Renderer>().material.color = Color.green;

		}
		else{
			selectionCube.gameObject.GetComponent<Renderer>().material.color = Color.red;
		}

	}

}
