using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    Rigidbody2D rb;
    public Collider2D CurrentPlatform;

	void Start () {
        rb = GetComponent<Rigidbody2D>();
    }
	
	void Update () {


        if (CurrentPlatform != null)
        {

            Vector3 vectorFromPlatform = (CurrentPlatform.gameObject.transform.position - transform.position).normalized;
            Vector3 perpendicularVector = new Vector3(vectorFromPlatform.y, -vectorFromPlatform.x);

            if (Input.GetButtonDown("Jump"))
            {
                rb.velocity = Vector3.zero;
                Vector3 closestPoint = CurrentPlatform.bounds.ClosestPoint(transform.position);
                Vector3 up = closestPoint - transform.position;
                rb.AddForce(up * -10, ForceMode2D.Impulse);
                CurrentPlatform.GetComponent<GravitedPlatform>().PlayerLeavesPlatform();
                CurrentPlatform = null;
                Debug.Log(vectorFromPlatform * -20);
                return;
            }

            float movx = Input.GetAxis("Horizontal");

            rb.AddForce(perpendicularVector * -movx * 15);
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, 5);
        }
    }

    private void LateUpdate()
    {
        if (CurrentPlatform != null && Mathf.Abs(Input.GetAxis("Horizontal")) < 0.2)
        {
            rb.velocity = Vector3.zero;
        }
    }
}
