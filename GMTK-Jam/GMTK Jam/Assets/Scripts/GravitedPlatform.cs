﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitedPlatform : MonoBehaviour {

    GameObject player;
    Rigidbody2D player_rb;
    Collider2D collider;

    bool playerIsInRange = false;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        player_rb = player.GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if (playerIsInRange)
        {
            Vector3 closestPoint = collider.bounds.ClosestPoint(player.transform.position);
            player_rb.AddForce((closestPoint - player.transform.position).normalized * 100);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            playerIsInRange = true;
            var blu = player.GetComponent<PlayerController>().CurrentPlatform;
            if (blu != null) blu.GetComponent<GravitedPlatform>().PlayerLeavesPlatform();
            player.GetComponent<PlayerController>().CurrentPlatform = collider;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsInRange = false;

            player.GetComponent<PlayerController>().CurrentPlatform = null;
        }
    }

    public void PlayerLeavesPlatform()
    {
        playerIsInRange = false;
    }
}