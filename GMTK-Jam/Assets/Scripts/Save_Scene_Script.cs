using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Save_Scene_Script : MonoBehaviour {

	// Use this for initialization
	void Start () {

        PlayerPrefs.SetString("Name_Scene", (Application.loadedLevelName));
       
        Debug.Log(PlayerPrefs.GetString("Name_Scene"));
	}
	
}
