using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public AudioClip wifePunch;
    public AudioClip bearPunch;

    public float speed;
    public float punchForce;
    public float distFromSweetSpot;
    public float endurance;
    public bool standOnFlag;
    public float calculatedShit;
    float timer;
    bool punchModeWife;
    bool punchModeBear;
    Rigidbody2D rb;
    GameObject bear, wife, golfSlider;
    public GameObject golfBarSlider;
    public Animator anim;
    Transform player;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        golfSlider = GameObject.Find("GolfSlider");
        bear = GameObject.FindGameObjectWithTag("Bear");
        wife = GameObject.FindGameObjectWithTag("Wife");

        anim = GetComponent<Animator>();
        endurance = GetComponent<Endurance>().endurance;
        rb.bodyType = RigidbodyType2D.Dynamic;
        golfBarSlider.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        Move(Input.GetAxisRaw("Horizontal"));
        if (anim.GetBool("winching") == true)
        {
            transform.rotation = Quaternion.identity;
        }
        if (punchModeWife == true)
        {
            rb.bodyType = RigidbodyType2D.Static;
            golfBarSlider.SetActive(true);
            wife.GetComponent<TempWifeScriptByJussi>().speed = 0;

            if (Input.GetKeyDown(KeyCode.Space))
            { 
                SoundManager.instance.RandomizeSfx(wifePunch);
                Vector2 dir = new Vector2(-5, 2).normalized;
                PunchForceAmount();
                wife.gameObject.GetComponent<Rigidbody2D>().AddForce(dir * punchForce);
                anim.SetTrigger("punchTrigger");
                wife.GetComponent<TempWifeScriptByJussi>().speed = wife.GetComponent<TempWifeScriptByJussi>().defaultSpeed;
                punchForce = 10000;
                golfBarSlider.SetActive(false);
                punchModeWife = false;
<<<<<<< HEAD
                //SoundManager.instance.RandomizeSfx(hit);

            }
        }

        if  (punchModeBear == true)
=======

            }
        }
        if (punchModeBear == true)
>>>>>>> JussiOksa
        {
            rb.bodyType = RigidbodyType2D.Static;
            golfBarSlider.SetActive(true);
            bear.GetComponent<TempBearScriptByJussi>().speed = 0;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SoundManager.instance.RandomizeSfx(bearPunch);
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
        //Debug.Log(horizontalInput);

    }
    private void PunchForceAmount()
    {
        distFromSweetSpot = golfSlider.GetComponent<GolfSlider>().distFromSweetSpot;
        endurance = GetComponent<Endurance>().endurance;
        calculatedShit = punchForce / (distFromSweetSpot * 10) * endurance;
        if (calculatedShit >= 50000)
        {
            punchForce = 45000;
        }
        if (calculatedShit >= 7600 && calculatedShit < 50000)
        {
            punchForce = 30000;
        }
        if (calculatedShit >= 3000 && calculatedShit < 7600)
        {
            punchForce = 23000;
        }
        if (calculatedShit >= 2272 && calculatedShit < 300)
        {
            punchForce = 12000;
        }
        if (calculatedShit <= 2271)
        {
            punchForce = 5000;
        }

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
