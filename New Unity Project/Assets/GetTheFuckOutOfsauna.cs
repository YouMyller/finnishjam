﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTheFuckOutOfsauna : MonoBehaviour
{
    GameObject player;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Sauna"))
        {
            player.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
