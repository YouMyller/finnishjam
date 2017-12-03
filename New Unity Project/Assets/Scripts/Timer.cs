using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timeLeft;
    public Text countdownText;

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(timeLeft / 60F);
        int seconds = Mathf.FloorToInt(timeLeft - minutes * 60);
        string niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);
        countdownText.text = niceTime;

        if (timeLeft <= 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        timeLeft = 0;
        //Add stuff here when we know what to do
        //countdownText.text = "It's ogre";

        SceneManager.LoadScene("YouLost");
    }
}
