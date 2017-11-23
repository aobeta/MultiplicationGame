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
        gameController.gameWinningText = buttonText.text;
        button.interactable = false;
        gameController.openQuestionBox();
    }

    public void setGameController(GameController controller)
    {
        gameController = controller;
    }

    public void assignButtonIndex(int index)
    {
        assignedButtonIndex = index;
    }

}
