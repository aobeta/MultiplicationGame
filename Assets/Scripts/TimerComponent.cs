﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerComponent : MonoBehaviour {

    public float time = 60;
    public Text countdownText;

    private GameController gameController;
    private MainGameController mainGameCtrl;


    void Start()
    {
        countdownText = GetComponent<Text>() as Text;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        countdownText.text =  Mathf.Round(time).ToString();
        if(gameController != null)
        {
            if (time < 1 || gameController.gameDone)
            {
                gameController.gameOver();
                countdownText.text = "done";
            }
        }
        else
        {
            if (time < 1 || mainGameCtrl.gameDone)
            {
                mainGameCtrl.gameOver();
                countdownText.text = "done";
            }
        }
    }

    public void setGameController(GameController controller)
    {
        gameController = controller;
    }

    public void setMainGameController(MainGameController ctrl)
    {
        mainGameCtrl = ctrl;
    }

}
