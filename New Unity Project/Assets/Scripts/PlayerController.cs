using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public bool standOnFlag;
    Rigidbody2D rb;
    GameObject enemy;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        rb.bodyType = RigidbodyType2D.Dynamic;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move(Input.GetAxisRaw("Horizontal"));
    }
    private void Move(float horizontalInput)
    {
        Vector2 moveVel = rb.velocity;
        moveVel.x = horizontalInput * speed;
        rb.velocity = moveVel;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            rb.bodyType = RigidbodyType2D.Static;
            enemy.GetComponent<TempBearScriptByJussi>().speed = 0;
        }
    }
}
