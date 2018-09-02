using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    public GameObject SpawnPoint;
    private GameObject player;

	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        PlayerController.OnDied += RespawnPlayer;
    }
	
	void Update () {
		
	}

    public void RespawnPlayer()
    {
        player.transform.position = SpawnPoint.transform.position;
    }
}
