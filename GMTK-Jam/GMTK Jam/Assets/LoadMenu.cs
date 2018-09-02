using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("LoadMenu1", 3);

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadMenu1()
    {
        SceneManager.LoadScene("Menu_Scene");
    }
}
