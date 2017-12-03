using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Endurance : MonoBehaviour
{

    public float endurance;
    public float maxEndurance;
    public bool sauna, saunaExtra, flag, enemy, snap;
    public GameObject buttonTutorial;
    public Sprite walkingSprite;
    public Transform snapPosition;

    [SerializeField]
    int flagNumber;
    float flagNumberTimerAmount = 0.0f;
    bool flagNumberTimer;

    public float flagDrop;
    public float flagPower;

    public AudioClip audioClip;
    public AudioClip audioClipTwo;

    public AudioClip sauna1;
    public AudioClip sauna2;
    public AudioClip sauna3;

    public Image currentEndurance;

    GameObject flagPole;

    // Use this for initialization
    void Start()
    {
        sauna = false;
        flag = false;
        enemy = false;
        saunaExtra = false;
        endurance = 100;
        maxEndurance = 20;

        flagDrop = 1;
        flagPower = 1;

        flagNumberTimer = true;
         
        //source.clip = audioClip;
        //source.clip = audioClipTwo;
    }

    // Update is called once per frame
    void Update()
    {   
        if (endurance <= 0)
        {
            endurance = 0;
        }
        if (sauna == true && GetComponent<SpriteRenderer>().enabled == false)
        {

            if (Input.GetKeyDown(KeyCode.A))
            {
                if (endurance <= 95)
                {
                    endurance += 1f;
                    SoundManager.instance.RandomizeSfx(sauna1, sauna2, sauna3);
                }
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                if (endurance <= 95)
                {
                    endurance += 1f;
                }
            }
        }

        FlagPoleTimer(false);


        if (flag == true)      //&& GetComponent<SpriteRenderer>().sprite != walkingSprite
        {
            
            if (Input.GetKeyDown(KeyCode.A))
                {
                    if (endurance >= 20)
                    {
                    
                    endurance -= 1f;
                        flagNumber += 10;
                        transform.position = snapPosition.position;
                }
                }

                if (Input.GetKeyDown(KeyCode.D))
                {
                    if (endurance >= 5)
                    {
                        endurance -= 1f;
                        flagNumber += 10;
                        transform.position = snapPosition.position;
                    }
                }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                flag = false;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                flag = false;
            }
        }

        if (enemy == true)
        {
            if (Input.GetKeyUp("space"))
            {
                enemy = false;
                endurance -= 20;
            }
        }

        float ratio = endurance / maxEndurance;
        currentEndurance.rectTransform.localScale = new Vector3(ratio, 1, 1);

        if (endurance > 100)
        {
            flagPower = 20;
        }
        if (endurance < 100)
        {
            flagPower = 12;
        }
        if (endurance < 50)
        {
            flagPower = 8;
        }
        if (endurance < 25)
        {
            flagPower = 5;
        }
        if (endurance <= 0)
        {
            flagPower = 0;
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
                    flagDrop = 5;
                    flagNumber -= 5;
                    flagNumberTimerAmount -= 1.0f;
                }
                else
                {
                    flagDrop = 1;
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
        if (collision.gameObject.tag == "SnapObject")
        {
            flag = true;
        }

        if (collision.gameObject.tag == "Sauna")
        {
            sauna = true;
        }
        else
        {
            sauna = false;
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
        }
        if (collision.gameObject.tag == "Sauna")
        {
            sauna = false;
            saunaExtra = false;
        }
    }
}
