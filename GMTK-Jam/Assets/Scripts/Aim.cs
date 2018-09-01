using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour {

    public GameObject AimSprite;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.rotation = Quaternion.identity;
        /*Vector3 lookVec = new Vector3(Input.GetAxis("HorizontalRight"), Input.GetAxis("VerticalRight"), 0);
        Quaternion targetRotation = Quaternion.LookRotation(lookVec, Vector3.back);
        Debug.Log(lookVec);
        AimSprite.transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime);*/

        var direction = new Vector3(-Input.GetAxis("HorizontalRight"), -Input.GetAxis("VerticalRight"), 0);

        transform.up = direction;
    }
}
