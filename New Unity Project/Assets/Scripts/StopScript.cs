using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopScript : MonoBehaviour
{
    GameObject bear, waifu;
    // Use this for initialization
    void Start()
    {
        bear = GameObject.FindGameObjectWithTag("Bear");
        waifu = GameObject.FindGameObjectWithTag("Wife");
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bear"))
        {
            bear.GetComponent<TempBearScriptByJussi>().speed = 0;
        }
        if (collision.gameObject.CompareTag("Wife"))
        {
            waifu.GetComponent<TempWifeScriptByJussi>().speed = 0;
        }
    }
}
