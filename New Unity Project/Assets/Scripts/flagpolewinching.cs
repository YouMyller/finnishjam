using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flagpolewinching : MonoBehaviour
{
    [SerializeField]
    int flagNumber;
    int flagNumberMax;
    bool flagNumberTimer;
    float flagNumberTimerAmount = 0.0f;

    GameObject player;
    GameObject enemy;

    void Start()
    {
        flagNumberTimer = true;

        player = GameObject.FindGameObjectWithTag("Player");
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        //player = GetComponent<playercontroller>();
    }

    void Update()
    {
        PressingADButtons();

        FlagPoleTimer(false);
    }

    void FlagPoleTimer(bool enemyTouches)
    {
        if (flagNumberTimer = true && flagNumber > 0)
        {
            flagNumberTimerAmount += Time.deltaTime;

            if (flagNumberTimerAmount > 1.0f)
            {
                if (enemyTouches == true)
                {
                    flagNumber -= 5;
                    flagNumberTimerAmount -= 1.0f;
                }
                else
                {
                    flagNumber -= 1;
                    flagNumberTimerAmount -= 1.0f;
                }
            }

            if (flagNumber <= 0)
            {
                flagNumber = 0;
            }
        }
    }

    void PressingADButtons()
    {
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

    //When enemy is in the flagpole's collider
    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            FlagPoleTimer(true);
            Debug.Log("Jou kosketti");
        }
    }
}
