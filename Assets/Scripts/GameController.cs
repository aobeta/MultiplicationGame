using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Analytics;

public class GameController : MonoBehaviour {

    public Button[] buttonList;
    public int numberOfBombs;
    private int bombsToBeFound;

    private int[] chosenButtonIndexes;
    private int chosenButtonIndex;
    private System.Random randomGenerator = new System.Random();
    public bool gameDone;

    //game over panel
    public GameObject gameOverPanel;

    //question board stuff
    public GameObject questionBoardPanel;
    public GameObject questionBoardComponent;

    public Text timer;
    public GameObject scoreBoard;

    public GameObject starsPanel;
    public Sprite oneStars;
    public Sprite twoStars;
    public Sprite threeStars;
    public Sprite zeroStars;

    public Button nextLevel;

    void Awake()
    {
        gameDone = false;
        gameOverPanel.SetActive(false);
        questionBoardComponent.GetComponent<QuestionBoardController>().setGameController(this);
        questionBoardPanel.SetActive(false);
        if (numberOfBombs == 0)
            numberOfBombs = 1;
        chosenButtonIndexes = new int[numberOfBombs];
        bombsToBeFound = numberOfBombs;
        setScoreBoardText(numberOfBombs,bombsToBeFound);
        setGameControllerReferenceOnButtons();
    }

    void setGameControllerReferenceOnButtons()
    {
        Debug.Log("Length of buttonList" + buttonList.Length);
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponent<GridBehaviourScript>().setGameController(this);
            buttonList[i].GetComponent<GridBehaviourScript>().assignButtonIndex(i);
        }
        timer.GetComponent<TimerComponent>().setGameController(this);
        for(int i =0; i < chosenButtonIndexes.Length; i++)
        {
            int newRandomIndex = randomGenerator.Next(buttonList.Length + 1);
            bool buttonSet = false;
            if(buttonList[newRandomIndex].GetComponent<GridBehaviourScript>().getSecretButtonText() != "W")
            {
                Debug.Log("W set at random index : " + newRandomIndex);
                buttonList[newRandomIndex].GetComponent<GridBehaviourScript>().setSecretButtonText("W");
                buttonSet = true;
            }
            else
            {
                while (!buttonSet)
                {
                    newRandomIndex = randomGenerator.Next(buttonList.Length + 1);
                    if(buttonList[newRandomIndex].GetComponent<GridBehaviourScript>().getSecretButtonText() != "W")
                    {
                        Debug.Log("W set at random index : " + newRandomIndex);
                        buttonList[newRandomIndex].GetComponent<GridBehaviourScript>().setSecretButtonText("W");
                        buttonSet = true;
                    }
                }
            }
        }
    }

    public void recordBombsFound()
    {
        bombsToBeFound--;
        setScoreBoardText(numberOfBombs,bombsToBeFound);
    }

    public void setScoreBoardText(int denominator, int numerator)
    {
        int found = denominator - numerator;
        scoreBoard.GetComponentInChildren<Text>().text = found.ToString() + " of " + denominator.ToString() + " found";
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
        if (bombsToBeFound == 0)
        {
            StartCoroutine(ExecuteAfterTime(1));
            gameOver("All Bombs Found!");
        }
    }

    public void gameOver(string optionalMessage)
    {
        if (gameDone)
            return;

        questionBoardPanel.SetActive(false);
        gameOverPanel.SetActive(true);
        if(optionalMessage != null)
        {
            gameOverPanel.GetComponentInChildren<Text>().text = optionalMessage;
        }
        gameDone = true;
        determineStars();

        if(bombsToBeFound != 0 && nextLevel != null)
        {
            nextLevel.interactable = false;
        }
    }

    public void determineStars()
    {
        int time = Int32.Parse(timer.text.Trim());
        if(bombsToBeFound > 0)
        {
            starsPanel.GetComponent<Image>().sprite = zeroStars;
        }
        else if(time >= 40)
        {
            starsPanel.GetComponent<Image>().sprite = threeStars;
        }
        else if(time >= 20)
        {
            starsPanel.GetComponent<Image>().sprite = twoStars;
        }
        else if(time >= 5)
        {
            starsPanel.GetComponent<Image>().sprite = oneStars;
        }
        else
        {
            starsPanel.GetComponent<Image>().sprite = zeroStars;
        }
    }

    public void gameOver()
    {
        if (gameDone)
            return;
        questionBoardPanel.SetActive(false);
        gameOverPanel.SetActive(true);
        gameDone = true;
        determineStars();

        if (bombsToBeFound != 0 && nextLevel != null)
        {
            nextLevel.interactable = false;
        }
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        Debug.Log("execute after time called");
        yield return new WaitForSeconds(time);
    }

}
