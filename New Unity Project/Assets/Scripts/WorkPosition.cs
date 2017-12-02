using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkPosition : MonoBehaviour {

    public GameObject buttonTutorial;
    public Transform snapPosition;
    private bool newSprite;
    public Sprite workingSprite;
    public Sprite walkingSprite;

    private bool timeToWork;
    private bool timeToSauna;

    //if sprite is ehhh then also hide the button

	// Use this for initialization
	void Start ()
    {
        timeToWork = false;
    }

    void Update()
    {
        if (timeToWork == true)
        {
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                buttonTutorial.SetActive(false);
                buttonTutorial.GetComponent<SpriteRenderer>().enabled = false;
                GetComponent<SpriteRenderer>().sprite = workingSprite;
                if (buttonTutorial.activeInHierarchy == true || GetComponent<SpriteRenderer>().sprite == workingSprite)
                {
                    buttonTutorial.SetActive(false);
                    buttonTutorial.GetComponent<SpriteRenderer>().enabled = false;
                }
                transform.position = snapPosition.position;
                //GetComponent<FlagUpDown>().enabled = true;
            }
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
            {
                GetComponent<SpriteRenderer>().sprite = walkingSprite;
                buttonTutorial.SetActive(true);
                buttonTutorial.GetComponent<SpriteRenderer>().enabled = true;
            }
        }

        if (timeToSauna == true)
        {
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                GetComponent<SpriteRenderer>().enabled = false;
                buttonTutorial.GetComponent<SpriteRenderer>().enabled = false;
                //GetComponent<FlagUpDown>().enabled = true;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "FlagPole")
        {
            buttonTutorial.SetActive(true);
        }
        if (collision.gameObject.tag == "Sauna")
        {
            buttonTutorial.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "FlagPole")
        {
            //buttonTutorial.SetActive(true);

            timeToWork = true;
        }

        if (collision.gameObject.tag == "Sauna")
        {
            //buttonTutorial.SetActive(true);

            timeToSauna = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "FlagPole")
        {
            buttonTutorial.SetActive(false);

            timeToWork = false;
            GetComponent<SpriteRenderer>().sprite = walkingSprite;
            //GetComponent<FlagUpDown>().enabled = false;
        }
        if (collision.gameObject.tag == "Sauna")
        {
            buttonTutorial.SetActive(false);

            timeToSauna = false;
            buttonTutorial.GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<SpriteRenderer>().enabled = true;
            //GetComponent<FlagUpDown>().enabled = false;
        }
    }

}
