using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    Rigidbody2D rb;
    public Collider2D CurrentPlatform;
    public GameObject Aim;

    public int Energy = 3;

    public delegate void DieAction();
    public static event DieAction OnDied = delegate { };


    public Image bar;
    public Image badBar;
    public Image bloc1;
    public Image bloc2;
    public Image bloc3;


    void Start () {
        ActivateTransparencyBar();
        rb = GetComponent<Rigidbody2D>();
        bar = GameObject.Find("Energy").GetComponent<Image>();
        badBar = GameObject.Find("Energy (1)").GetComponent<Image>();
        bloc1 = GameObject.Find("Energy1").GetComponent<Image>();
        bloc2 = GameObject.Find("Energy2").GetComponent<Image>();
        bloc3 = GameObject.Find("Energy3").GetComponent<Image>();
    }
	
	void Update () {
       Debug.DrawLine(transform.position, transform.position + -Aim.transform.up, Color.white, 1f, false);

        if (CurrentPlatform != null)
        {

            Vector3 vectorFromPlatform = (CurrentPlatform.gameObject.transform.position - transform.position).normalized;
            Vector3 perpendicularVector = new Vector3(vectorFromPlatform.y, -vectorFromPlatform.x);

            if (Input.GetButtonDown("Jump"))
            {
                if (Mathf.Abs(Input.GetAxis("HorizontalRight")) < 0.1f && Mathf.Abs(Input.GetAxis("VerticalRight")) < 0.1f)
                {
                    return;
                }
                rb.velocity = Vector3.zero;
                //Vector3 closestPoint = CurrentPlatform.bounds.ClosestPoint(transform.position);
                //Vector3 up = closestPoint - transform.position;
                RaycastHit2D hit = Physics2D.Raycast(transform.position, -Aim.transform.up, 0.5F, 1 << LayerMask.NameToLayer("Enemy"));
                DeactivateTransparencyBar();
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
                Invoke("ActivateTransparencyBar", 1f);
                return;
            }
            float movx = Input.GetAxis("Horizontal");
            float movy = Input.GetAxis("Vertical");
            rb.AddForce(perpendicularVector * -movx * 15);
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, 5);
            /*
            float movx = Input.GetAxis("Horizontal");
            
            rb.AddForce(new Vector3(movx, movy, 1) * 15);
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, 5);*/


        }
        UpdateEnergyBar();
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

    public void UpdateEnergyBar()
    {
        if (Energy == 3)
        {
            bloc3.enabled = true;
            bloc2.enabled = true;
            bloc1.enabled = true;
            badBar.enabled = false;
            bar.enabled = true;
        }
        if (Energy == 2)
        {
            bloc3.enabled = false;
            bloc2.enabled = true;
            bloc1.enabled = true;
            badBar.enabled = false;
            bar.enabled = true;
        }
        if (Energy == 1)
        {
            bloc3.enabled = false;
            bloc2.enabled = false;
            bloc1.enabled = true;
            badBar.enabled = false;
            bar.enabled = true;
        }
        if (Energy == 0)
        {
            bloc3.enabled = false;
            bloc2.enabled = false;
            bloc1.enabled = false;
            badBar.enabled = true;
            bar.enabled = false;
        }
    }

    public void ActivateTransparencyBar()
    {
        Color newColor = bar.color;
        newColor.a = 0.5f;
        bloc3.color = newColor;
        bloc2.color = newColor;
        bloc1.color = newColor;
        bar.color = newColor;
        badBar.color = newColor;
    }

    public void DeactivateTransparencyBar()
    {
        Color newColor = bar.color;
        newColor.a = 1;
        bloc3.color = newColor;
        bloc2.color = newColor;
        bloc1.color = newColor;
        bar.color = newColor;
        badBar.color = newColor;
    }
}
