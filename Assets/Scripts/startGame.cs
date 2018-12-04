using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class startGame : MonoBehaviour {


	public Button start;
	public Button load_save;
	public Button settings;
	public Button exit;


	void Start () {
        start.onClick.AddListener(Load_First_Level);
		load_save.onClick.AddListener(Load_Save);
		settings.onClick.AddListener(Load_Settings);
		exit.onClick.AddListener(Application.Quit);

	}


    public void Load_First_Level(){
        print("Loading");
        SceneManager.LoadScene("basic_level", LoadSceneMode.Single);
    }

	public void Load_Settings(){
        print("Loading");
        SceneManager.LoadScene("settings_menu", LoadSceneMode.Single);
    }
	public void Load_Save(){
        print("Loading");
        SceneManager.LoadScene("Leaderboard", LoadSceneMode.Single);
    }
}
