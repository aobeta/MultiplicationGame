using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Analytics;

public class GameController : MonoBehaviour {

    public Button[] buttonList;
    public int numberOfBombs;
    private int bombsFound;

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
    //public string gameWinningText;

    void Awake()
    {
        gameDone = false;
        gameOverPanel.SetActive(false);
        questionBoardComponent.GetComponent<QuestionBoardController>().setGameController(this);
        questionBoardPanel.SetActive(false);
        if (numberOfBombs == 0)
            numberOfBombs = 1;
        chosenButtonIndexes = new int[numberOfBombs];
        bombsFound = numberOfBombs;
        setScoreBoardText(numberOfBombs, bombsFound);
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
        bombsFound--;
        Debug.Log("Bombs found? " + bombsFound);
        setScoreBoardText(numberOfBombs, bombsFound);
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
        if (bombsFound == 0)
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
        gameOver("You Found All The Bombs!");
    }

}
