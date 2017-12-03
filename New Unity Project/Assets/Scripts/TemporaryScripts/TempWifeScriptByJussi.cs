using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempWifeScriptByJussi : MonoBehaviour
{
    public float speed;
    public float defaultSpeed;
    public Animator anim;
    Rigidbody2D rb;
    
    GameObject player;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(Vector2.right * speed);
        anim.SetFloat("Speed", speed);
        if (transform.position.y > 1)
        {
            anim.SetBool("isGrounded", false);
        }
        else
        {
            anim.SetBool("isGrounded", true);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "FlagPole")
        {
            player.GetComponent<Endurance>().FlagPoleTimer(true);
            Debug.Log("Jou kosketti");
        }
    }
}
