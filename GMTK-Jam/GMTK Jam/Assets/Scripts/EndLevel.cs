using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour {

    public string next_scene;
    public Animator animator;
    public Sprite sprite;

	void Start () {
        animator = GameObject.Find("Fade").GetComponent<Animator>();

    }

	void Update () {

	}

    void OnTriggerEnter2D(Collider2D other)
    {
        AkSoundEngine.PostEvent("Play_Bip_Antenne", gameObject);
        if (!other.CompareTag("Player")) return;
        other.GetComponent<PlayerController>().enabled = false;
        other.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        othe.SetActive(false);
        animator.SetTrigger("Fade");
        GetComponent<SpriteRenderer>().sprite = sprite;
        Invoke("LoadScene", 3);
        Invoke("PlayBipBip", 0.85f);
    }

    void LoadScene()
    {
        SceneManager.LoadScene(next_scene);
    }

    void PlayBipBip()
    {
        AkSoundEngine.PostEvent("Play_Voice_Win", gameObject);
    }
}
