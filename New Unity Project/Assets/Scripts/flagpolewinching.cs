using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flagpolewinching : MonoBehaviour
{
    GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //player = GetComponent<playercontroller>();
    }

    void Update()
    {

    }

    //When enemy is in the flagpole's collider
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "KarhuTrigger" && collision.gameObject.tag == "Wife")
        {
            player.GetComponent<Endurance>().FlagPoleTimer(true);
            Debug.Log("Jou kosketti");
        }
    }
}
