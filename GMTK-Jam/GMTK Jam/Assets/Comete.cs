using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comete : MonoBehaviour {

    public Animator anim;

	// Use this for initialization
	void Start () {
        StartCoroutine(spawnComete());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator spawnComete()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(7f, 18f));
            anim.SetTrigger("run");
        }
    }
}
