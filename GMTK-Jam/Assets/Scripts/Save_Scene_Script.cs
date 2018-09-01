using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Save_Scene_Script : MonoBehaviour {


    //Scene CurrentScene;
    private string Namescene;
   

    void Start () {


        Namescene = SceneManager.GetActiveScene().name;
        //CurrentScene = SceneManager.GetActiveScene().Name;

        PlayerPrefs.SetString("Name_Scene", Namescene);

        // Namescene = CurrentScene;
        //Debug.Log(Namescene);
        Debug.Log(PlayerPrefs.GetString("Name_Scene"));
	}
	
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            {
            //print("space key was pressed");
            SceneManager.LoadScene("Menu_Scene");
        }

    }

}
