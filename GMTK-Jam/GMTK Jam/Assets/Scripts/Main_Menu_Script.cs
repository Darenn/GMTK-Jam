using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu_Script : MonoBehaviour {

    public GameObject LOADBUTT;


    void Start()
    {
        //PlayerPrefs.DeleteAll();
        AkSoundEngine.PostEvent("Play_Music_Menu", gameObject);

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
        AkSoundEngine.PostEvent("Play_UI", gameObject);
        AkSoundEngine.PostEvent("Play_Music", gameObject);
    }


    public void LoadGame()
    {
        AkSoundEngine.PostEvent("Play_UI", gameObject);
        if (PlayerPrefs.HasKey("Name_Scene")) {

            //Debug.Log(PlayerPrefs.GetString("Name_Scene"));
            AkSoundEngine.PostEvent("Play_Music", gameObject);
            SceneManager.LoadScene(PlayerPrefs.GetString("Name_Scene"));
        }
    }

    public void QuitGame()
    {
        AkSoundEngine.PostEvent("Play_UI", gameObject);
        Application.Quit();
    }
}
