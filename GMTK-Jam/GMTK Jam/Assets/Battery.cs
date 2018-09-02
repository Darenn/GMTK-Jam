using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            var pl = other.GetComponent<PlayerController>();
            if (pl.Energy < 3)
            {
                AkSoundEngine.PostEvent("Play_Energy", gameObject);
                pl.Energy++;
                gameObject.SetActive(false);
            }    
        }
    }
}
