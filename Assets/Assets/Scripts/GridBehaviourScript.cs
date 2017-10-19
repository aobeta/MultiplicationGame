using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GridBehaviourScript : MonoBehaviour {

    public Button button;
    public Text buttonText;
    public string PlayerSide;

    private int assignedButtonIndex;
    private GameController gameController;

    public void setSpace()
    {
        buttonText.text = assignedButtonIndex == gameController.getChosenButtonIndex()? "W" : "";
        button.interactable = false;
        if(buttonText.text.Equals("W"))
        {
            StartCoroutine(ExecuteAfterTime(1));
        }
        else
        {
            gameController.openQuestionBox();
        }
    }

    public void setGameController(GameController controller)
    {
        gameController = controller;
    }

    public void assignButtonIndex(int index)
    {
        assignedButtonIndex = index;
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        gameController.gameOver();
    }

}
