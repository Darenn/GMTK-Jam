﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour {

    public EndLevel end;
    public GameObject SpawnPoint;
    public GravitedPlatform StartPlatform;
    private GameObject player;

	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        PlayerController.OnDied += RespawnPlayer;
    }
	
	void Update () {
		
	}

    public void RespawnPlayer()
    {
        /*player.transform.position = SpawnPoint.transform.position;
        player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        StartPlatform.attractPlayer();*/
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}