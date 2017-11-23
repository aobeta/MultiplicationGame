﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Analytics;

public class GameController : MonoBehaviour {

    public Text[] buttonList;
    private int chosenButtonIndex;
    private System.Random randomGenerator = new System.Random();
    public bool gameDone;

    //game over panel
    public GameObject gameOverPanel;

    //question board stuff
    public GameObject questionBoardPanel;
    public GameObject questionBoardComponent;

    public Text timer;
    public string gameWinningText;

    void Awake()
    {
        gameDone = false;
        gameOverPanel.SetActive(false);
        questionBoardComponent.GetComponent<QuestionBoardController>().setGameController(this);
        questionBoardPanel.SetActive(false);
        setGameControllerReferenceOnButtons();  
    }

    void setGameControllerReferenceOnButtons()
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<GridBehaviourScript>().setGameController(this);
            buttonList[i].GetComponentInParent<GridBehaviourScript>().assignButtonIndex(i);
        }
        timer.GetComponent<TimerComponent>().setGameController(this);
        chosenButtonIndex = randomGenerator.Next(buttonList.Length + 1);
    }

    public int getChosenButtonIndex()
    {
        return chosenButtonIndex;
    }

    public void openQuestionBox()
    {
        questionBoardPanel.SetActive(true);
        questionBoardComponent.GetComponent<QuestionBoardController>().refreshQuestionAndAnswer();
    }

    public void closeQuestionBox()
    {
        questionBoardPanel.SetActive(false);
        evaluateCurrentButton();
    }

    public void evaluateCurrentButton()
    {
        if (gameWinningText.Equals("W"))
        {
            StartCoroutine(ExecuteAfterTime(1));
        }
    }

    public void gameOver(string optionalMessage)
    {
        questionBoardPanel.SetActive(false);
        gameOverPanel.SetActive(true);
        if(optionalMessage != null)
        {
            gameOverPanel.GetComponentInChildren<Text>().text = optionalMessage;
        }
        gameDone = true;
        Analytics.CustomEvent("game Over EXT");
    }

    public void gameOver()
    {
        questionBoardPanel.SetActive(false);
        gameOverPanel.SetActive(true);
        gameDone = true;
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        gameOver("You found a way to get the W!");
    }

}
