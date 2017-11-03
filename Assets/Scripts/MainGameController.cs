using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MainGameController : MonoBehaviour
{

    //public Text[] buttonList;
   // private int chosenButtonIndex;
    private System.Random randomGenerator = new System.Random();
    public bool gameDone;

    //game over panel
    public GameObject gameOverPanel;

    //question board stuff
    public GameObject questionBoardPanel;
    public GameObject questionBoardComponent;

    public Text timer;

    void Awake()
    {
        gameDone = false;
        gameOverPanel.SetActive(false);
        questionBoardComponent.GetComponent<QuestionBoardController>().setMainGameController(this);
        timer.GetComponent<TimerComponent>().setMainGameController(this);
        //questionBoardPanel.SetActive(false);
        //setGameControllerReferenceOnButtons();
    }


    public void gameOver(string optionalMessage)
    {
        questionBoardPanel.SetActive(false);
        gameOverPanel.SetActive(true);
        if (optionalMessage != null)
        {
            gameOverPanel.GetComponentInChildren<Text>().text = optionalMessage;
        }
        gameDone = true;
    }

    public void gameOver()
    {
        questionBoardPanel.SetActive(false);
        gameOverPanel.SetActive(true);
        gameDone = true;
    }

}
