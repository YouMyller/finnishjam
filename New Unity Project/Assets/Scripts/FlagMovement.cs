using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagMovement : MonoBehaviour
{

    GameObject player;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update ()
    {
        Endurance enduScript = player.GetComponent<Endurance>();

        if (enduScript.flag == true)
        {
            if (transform.position.y <= 7.30)
            {
                player.GetComponent<Endurance>().FlagPoleTimer(false);

                if (Input.GetKeyDown(KeyCode.A))
                {
                    transform.Translate(Vector2.up * Time.deltaTime * enduScript.flagPower, Space.World);
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    transform.Translate(Vector2.up * Time.deltaTime * enduScript.flagPower, Space.World);
                }
            }
        }

        if (transform.position.y > 1.48)
        {
            transform.Translate(Vector2.down * Time.deltaTime * enduScript.flagDrop, Space.World);
        }
    }
}
