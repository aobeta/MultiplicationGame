using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GridBehaviourScript : MonoBehaviour {

    public Button button;
    public Text buttonText;
    public string PlayerSide;

    public Sprite bombSprite;

    private int assignedButtonIndex;
    private GameController gameController;

    private string secretButtonText;

    public void setSpace()
    {
        buttonText.text = secretButtonText == "W" ? secretButtonText : "";
        if(buttonText.text == "W")
        {
            buttonText.text = "";
            button.GetComponent<Image>().sprite = bombSprite;
            gameController.recordBombsFound();
        }
        //gameController.gameWinningText = buttonText.text;
        button.interactable = false;
        gameController.openQuestionBox();
    }

    public void setGameController(GameController controller)
    {
        gameController = controller;
    }

    public string getSecretButtonText()
    {
        return secretButtonText;
    }

    public void setSecretButtonText(string value)
    {
        secretButtonText = value;
    }

    public void assignButtonIndex(int index)
    {
        assignedButtonIndex = index;
    }

}
