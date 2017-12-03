using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryScript : MonoBehaviour
{
    GameObject bear, wife;
    // Use this for initialization
    void Start()
    {
        bear = GameObject.FindGameObjectWithTag("Bear");
        wife = GameObject.FindGameObjectWithTag("Wife");
    }

    private void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bear")
        {
            Physics2D.IgnoreCollision(bear.GetComponent<Collider2D>(), GetComponent<Collider2D>(), true);
        }
        if (collision.gameObject.tag == "Wife")
        {
            Physics2D.IgnoreCollision(wife.GetComponent<Collider2D>(), GetComponent<Collider2D>(), true);
        }
    }
}
