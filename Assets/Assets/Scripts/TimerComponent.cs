using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerComponent : MonoBehaviour {

    public float time = 30;
    public Text countdownText;

    private GameController gameController;


    void Start()
    {
        countdownText = GetComponent<Text>() as Text;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        countdownText.text =  Mathf.Round(time).ToString();
        if(time < 1 || gameController.gameDone)
        {
            gameController.gameOver();
            countdownText.text = "done";
        }
    }

    public void setGameController(GameController controller)
    {
        gameController = controller;
    }

}
