using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class startGame : MonoBehaviour {


	public Button start;
	void Start () {
        start.onClick.AddListener(Load_First_Level);

	}


    public void Load_First_Level(){
        print("Loading");
        SceneManager.LoadScene("basic_level", LoadSceneMode.Single);
    }
}
