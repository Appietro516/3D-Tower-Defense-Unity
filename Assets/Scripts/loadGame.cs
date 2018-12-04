using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class loadGame : MonoBehaviour {

	public Button load_save;
	public Button back;


	void Start () {
        back.onClick.AddListener(Load_First_Level);
		load_save.onClick.AddListener(Load_Save);


	}

    public void Load_First_Level(){
        print("Loading");
        SceneManager.LoadScene("basic_level", LoadSceneMode.Single);
    }
	public void Load_Save(){
        print("Loading");
		Save.loadLeaderBoard();
        SceneManager.LoadScene("leaderboard", LoadSceneMode.Single);
    }
}
