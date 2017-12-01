using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flagpolewinching : MonoBehaviour
{
    [SerializeField]
    int flagNumber;
    int flagNumberMax;
    float flagNumberTimer = 0.0f;
    GameObject player;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //player = GetComponent<playercontroller>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (flagNumber > 0)
        {
            flagNumberTimer += Time.deltaTime;

            if (flagNumberTimer > 1.0f)
            {
                flagNumber -= 1;
                flagNumberTimer -= 1.0f;
            }
        }

        /*if (flagNumberDecreaseTimer == true)
        {
            
        }*/

        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Pressing A");
            flagNumber += 10;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("Pressing D");
            flagNumber += 10;
        }
    }
}
