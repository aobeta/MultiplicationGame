using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionBoardController : MonoBehaviour {

    private GameController gameController;

    private int value1;
    private int value2;
    private int correctAnswer;
    private string question;
    private string answerString;

    private System.Random randomGenerator = new System.Random();

    public Text questionText;

    //Buttons
    public Button bt0;
    public Button bt1;
    public Button bt2;
    public Button bt3;
    public Button bt4;
    public Button bt5;
    public Button bt6;
    public Button bt7;
    public Button bt8;
    public Button bt9;

    public Button enterButton;

    void Awake()
    {
        refreshQuestionAndAnswer();
        setButtonClickListeners();
        //StartCoroutine(ExecuteAfterTime(5));
    }

    public void refreshQuestionAndAnswer()
    {
        value1 = randomGenerator.Next(1, 13);
        value2 = randomGenerator.Next(1, 13);
        correctAnswer = value1 * value2;
        question = value1 + " x " + value2 + " = ?";
        questionText.text = question;
        answerString = "";
    }

    public void setGameController(GameController controlla)
    {
        gameController = controlla;
    }

    private void setButtonClickListeners()
    {
        bt0.GetComponent<Button>().onClick.AddListener(() => { setAnswerStringFromButton(bt0);  });
        bt1.GetComponent<Button>().onClick.AddListener(() => { setAnswerStringFromButton(bt1);  });
        bt2.GetComponent<Button>().onClick.AddListener(() => { setAnswerStringFromButton(bt2);  });
        bt3.GetComponent<Button>().onClick.AddListener(() => { setAnswerStringFromButton(bt3);  });
        bt4.GetComponent<Button>().onClick.AddListener(() => { setAnswerStringFromButton(bt4);  });
        bt5.GetComponent<Button>().onClick.AddListener(() => { setAnswerStringFromButton(bt5);  });
        bt6.GetComponent<Button>().onClick.AddListener(() => { setAnswerStringFromButton(bt6);  });
        bt7.GetComponent<Button>().onClick.AddListener(() => { setAnswerStringFromButton(bt7);  });
        bt8.GetComponent<Button>().onClick.AddListener(() => { setAnswerStringFromButton(bt8);  });
        bt9.GetComponent<Button>().onClick.AddListener(() => { setAnswerStringFromButton(bt9);  });

        enterButton.GetComponent<Button>().onClick.AddListener(() => { checkAnswer();  });
    }

    private void setAnswerStringFromButton(Button btn)
    {
        answerString = answerString + btn.GetComponentInChildren<Text>().text;
        setQuestionText();
    }

    private void checkAnswer()
    {
        int userAnswer = Int32.Parse(answerString);
        if (userAnswer.Equals(correctAnswer))
        {
            gameController.closeQuestionBox();
        }
        else
        {
            gameController.gameOver("The Correct Answer is " + correctAnswer);
        }
    }

    private void setQuestionText()
    {
        question = value1 + " x " + value2 + " = " + answerString;
        questionText.text = question;
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        Debug.Log("shoulding be closing questionbox");
        gameController.closeQuestionBox();
    }
}
