using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu_Script : MonoBehaviour {

	public void NewGame()
    {
        SceneManager.LoadScene("Level01");
    }


    public void QuitGame()
    {
        Application.Quit();
    }
}
