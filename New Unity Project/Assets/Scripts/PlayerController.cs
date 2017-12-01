using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float punchForce;
    public bool standOnFlag;
    float timer;
    bool punchModeWife;
    bool punchModeBear;
    Rigidbody2D rb;
    GameObject bear, wife;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bear = GameObject.FindGameObjectWithTag("Bear");
        wife = GameObject.FindGameObjectWithTag("Wife");
        rb.bodyType = RigidbodyType2D.Dynamic;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move(Input.GetAxisRaw("Horizontal"));

        if (punchModeWife == true)
        {
            rb.bodyType = RigidbodyType2D.Static;
            wife.GetComponent<TempWifeScriptByJussi>().speed = 0;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Vector2 dir = new Vector2(-5, 2).normalized;
                wife.gameObject.GetComponent<Rigidbody2D>().AddForce(dir * punchForce);
                punchModeWife = false;
                wife.GetComponent<TempWifeScriptByJussi>().speed = 50;
            }
        }
        if  (punchModeBear == true)
        {
            rb.bodyType = RigidbodyType2D.Static;
            bear.GetComponent<TempBearScriptByJussi>().speed = 0;
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Vector2 dir = new Vector2(5, 2).normalized;
                bear.gameObject.GetComponent<Rigidbody2D>().AddForce(dir * punchForce);
                punchModeBear = false;
                bear.GetComponent<TempBearScriptByJussi>().speed = 50;
            }
            
        }
        else
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            
        }
    }
    private void Move(float horizontalInput)
    {
        Vector2 moveVel = rb.velocity;
        moveVel.x = horizontalInput * speed;
        rb.velocity = moveVel;
    }
    private void PunchForceAmount()
    {

    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Bear")
        {
            punchModeBear = true;
        }
        if (coll.gameObject.tag == "Wife")
        {
            punchModeWife = true;
        }
    }
}
