using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    Rigidbody2D rb;
    public Collider2D CurrentPlatform;
    public GameObject Aim;

    public int Energy = 3;

    public delegate void DieAction();
    public static event DieAction OnDied = delegate { };


    void Start () {
        rb = GetComponent<Rigidbody2D>();
    }
	
	void Update () {
       Debug.DrawLine(transform.position, transform.position + -Aim.transform.up, Color.white, 1f, false);

        if (CurrentPlatform != null)
        {

            Vector3 vectorFromPlatform = (CurrentPlatform.gameObject.transform.position - transform.position).normalized;
            Vector3 perpendicularVector = new Vector3(vectorFromPlatform.y, -vectorFromPlatform.x);

            if (Input.GetButtonDown("Jump"))
            {
                rb.velocity = Vector3.zero;
                //Vector3 closestPoint = CurrentPlatform.bounds.ClosestPoint(transform.position);
                //Vector3 up = closestPoint - transform.position;
                RaycastHit2D hit = Physics2D.Raycast(transform.position, -Aim.transform.up, 0.5F, 1 << LayerMask.NameToLayer("Enemy"));
                if ((hit != null && hit.collider != null) || Energy == 0)
                {
                    AkSoundEngine.PostEvent("Play_NoJump", gameObject);
                    return;
                }
                Energy--;
                rb.AddForce(Aim.transform.up * -10, ForceMode2D.Impulse);
                CurrentPlatform.GetComponent<GravitedPlatform>().PlayerLeavesPlatform();
                CurrentPlatform = null;
                AkSoundEngine.PostEvent("Play_Jump", gameObject);
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

    public void Die()
    {
        AkSoundEngine.PostEvent("Play_Voice_Die", gameObject);
        OnDied();
    }
}
