using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu_Script : MonoBehaviour {

    public GameObject LOADBUTT;


    void Start()
    {
        //PlayerPrefs.DeleteAll();

    }

    void Update()
    {
        if (PlayerPrefs.HasKey("Name_Scene"))
        {
            LOADBUTT.SetActive(true);
        }

        else  {

            LOADBUTT.SetActive(false);
        }
    }

	public void NewGame()
    {
        SceneManager.LoadScene("Level01");
    }


    public void LoadGame()
    {

        if (PlayerPrefs.HasKey("Name_Scene")) {

            //Debug.Log(PlayerPrefs.GetString("Name_Scene"));

            SceneManager.LoadScene(PlayerPrefs.GetString("Name_Scene"));
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
