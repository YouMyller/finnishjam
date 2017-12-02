using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float punchForce;
    public float distFromSweetSpot;
    public bool standOnFlag;
    float timer;
    bool punchModeWife;
    bool punchModeBear;
    Rigidbody2D rb;
    GameObject bear, wife, golfSlider;
    public GameObject golfBarSlider;
    public Animator anim;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        golfSlider = GameObject.Find("GolfSlider");
        bear = GameObject.FindGameObjectWithTag("Bear");
        wife = GameObject.FindGameObjectWithTag("Wife");
        anim = GetComponent<Animator>();
        rb.bodyType = RigidbodyType2D.Dynamic;
        golfBarSlider.SetActive(false);
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move(Input.GetAxisRaw("Horizontal"));
        if (punchModeWife == true)
        {
            rb.bodyType = RigidbodyType2D.Static;
            golfBarSlider.SetActive(true);
            wife.GetComponent<TempWifeScriptByJussi>().speed = 0;
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Vector2 dir = new Vector2(-5, 2).normalized;
                PunchForceAmount();
                wife.gameObject.GetComponent<Rigidbody2D>().AddForce(dir * punchForce);
                anim.SetTrigger("punchTrigger");
                wife.GetComponent<TempWifeScriptByJussi>().speed = wife.GetComponent<TempWifeScriptByJussi>().defaultSpeed;
                punchForce = 10000;
                golfBarSlider.SetActive(false);
                punchModeWife = false;
                
            }
        }
        if  (punchModeBear == true)
        {
            rb.bodyType = RigidbodyType2D.Static;
            golfBarSlider.SetActive(true);
            bear.GetComponent<TempBearScriptByJussi>().speed = 0;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Vector2 dir = new Vector2(5, 2).normalized;
                PunchForceAmount();
                bear.gameObject.GetComponent<Rigidbody2D>().AddForce(dir * punchForce);
                anim.SetTrigger("punchTrigger");
                bear.GetComponent<TempBearScriptByJussi>().speed = bear.GetComponent<TempBearScriptByJussi>().defaultSpeed;
                punchForce = 10000;
                golfBarSlider.SetActive(false);
                punchModeBear = false;
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
        anim.SetFloat("horizontalInput", horizontalInput);
        if (horizontalInput == 1)
        {
            transform.localEulerAngles = new Vector3(0, 180, 0);
        }
        if (horizontalInput == -1)
        {
            transform.localEulerAngles = new Vector3(0, 360, 0);
        }
        Debug.Log(horizontalInput);

    }
    private void PunchForceAmount()
    {
        distFromSweetSpot = golfSlider.GetComponent<GolfSlider>().distFromSweetSpot;
        punchForce = (punchForce / distFromSweetSpot) * 25;
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
