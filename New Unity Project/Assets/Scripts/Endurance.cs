using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Endurance : MonoBehaviour {

    public float endurance;
    public float maxEndurance;
    private bool sauna, saunaExtra, flag, flagExtra, enemy, snap;
    public GameObject buttonTutorial;
    public Sprite walkingSprite;

    [SerializeField]
    int flagNumber;
    float flagNumberTimerAmount = 0.0f;
    bool flagNumberTimer;

    public Image currentEndurance;

    GameObject flagPole;

	// Use this for initialization
	void Start ()
    {
        sauna = false;
        flag = false;
        enemy = true;
        flagExtra = false;
        saunaExtra = false;
        endurance = 20;
        maxEndurance = 4;

        flagNumberTimer = true;
        //flagPole = GameObject.FindGameObjectWithTag("FlagPole");
	}

	// Update is called once per frame
	void Update ()
    {

        if (sauna == true && GetComponent<SpriteRenderer>().enabled == false)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                Debug.Log("Sauna works you fucks");
                endurance += .1f;
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                endurance += .1f;
            }
        }

        FlagPoleTimer(false);

        if (flag == true)
        {
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                flagExtra = true;
            }
        }

        if (flagExtra == true && GetComponent<SpriteRenderer>().sprite != walkingSprite)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                endurance -= .1f;
                flagNumber += 10;
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                endurance -= .1f;
                flagNumber += 10;
            }
        }
        if (enemy == true)
        {
            if (Input.GetKeyUp("space"))
            {
                endurance -= 4;
            }
        }

        float ratio = endurance / maxEndurance;
        currentEndurance.rectTransform.localScale = new Vector3(ratio, 1, 1);

        if (endurance > 20)
        {
            //hit power = 30
            //flag speed = 30;
        }
        if (endurance < 20)
        {
            //hit power = 20
            //flag speed = 20;
        }
        if (endurance < 10)
        {
            //hit power = 10
            //flag speed = 10;
        }
        if (endurance < 5)
        {
            //hit power = 5
            //flag speed = 5;
        }
        if (endurance <= 0)
        {
            //hit power = 0
            //flag speed = 0;
        }
    }

    public void FlagPoleTimer(bool enemyTouches)
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

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Sauna")
        {
            sauna = true;
            Debug.Log("Works so far");
        }
        else
        {
            sauna = false;
            Debug.Log("Sauna on false.");
        }

        if (collision.gameObject.tag == "FlagPole")
        {
            flag = true;
        }
        else
        {
            flag = false;
            flagExtra = false;
        }

        if (collision.gameObject.tag == "KarhuTrigger" || collision.gameObject.tag == "VaimoTrigger")
        {
            enemy = true;
        }
        else
        {
            enemy = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "FlagPole")
        {
            flag = false;
            flagExtra = false;
        }
        if (collision.gameObject.tag == "Sauna")
        {
            sauna = false;
            saunaExtra = false;
        }
    }
}
