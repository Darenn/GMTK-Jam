using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingPlat : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnCollisionEnter2D()
    {
        AkSoundEngine.PostEvent("Play_Bounce", gameObject);
    }
}
