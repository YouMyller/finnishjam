using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempBearScriptByJussi : MonoBehaviour
{
    public float speed;
    public float defaultSpeed;
    public Animator anim;
    Rigidbody2D rb;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(Vector2.left * speed);
        anim.SetFloat("Speed", speed);
        if (transform.position.y > 1.6)
        {
            anim.SetBool("isGrounded", false);
        }
        else
        {
            anim.SetBool("isGrounded", true);
        }
    }
}
