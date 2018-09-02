using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour {

	void Start ()
    {
		
	}

	void Update ()
    {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        var ply = other.GetComponent<PlayerController>();
        if (ply != null)
        {
            ply.Die();
        }
    }
}
