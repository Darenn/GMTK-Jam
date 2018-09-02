using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour {

    public string next_scene;

	void Start () {
		
	}

	void Update () {

	}

    void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene(next_scene);
    }
}
