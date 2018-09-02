using System.Collections;
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
            //Vector3 closestPoint = collider.bounds.ClosestPoint(player.transform.position);
            Vector3 closestPoint = collider.Distance(player.GetComponent<Collider2D>()).pointA;
            player_rb.AddForce((closestPoint - player.transform.position).normalized * 100);
            Debug.DrawLine(closestPoint, player.transform.position, Color.yellow, 1f, false);       
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            attractPlayer();
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

    public void attractPlayer()
    {
        playerIsInRange = true;
        var blu = player.GetComponent<PlayerController>().CurrentPlatform;
        GravitedPlatform plat = null;
        if (blu != null) plat = blu.GetComponent<GravitedPlatform>();
        if (plat != null && plat != this) plat.PlayerLeavesPlatform();
        player.GetComponent<PlayerController>().CurrentPlatform = collider;
    }
}
