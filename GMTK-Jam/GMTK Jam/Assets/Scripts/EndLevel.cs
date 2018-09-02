using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour {

    public string next_scene;
    public Animator animator;

	void Start () {
		
	}

	void Update () {

	}

    void OnTriggerEnter2D(Collider2D other)
    {
        animator.SetTrigger("Fade");
        Invoke("LoadScene", 3);
        AkSoundEngine.PostEvent("Play_Voice_Win", gameObject);
    }

    void LoadScene()
    {
        SceneManager.LoadScene(next_scene);
    }
}
