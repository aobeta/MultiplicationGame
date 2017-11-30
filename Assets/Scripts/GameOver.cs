using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public int level;

    public void returnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void playAgain()
    {
        SceneManager.LoadScene(level + 3);
    }

    public void loadNextLevel()
    {
        int newL = level + 4;
        Debug.Log("level is : " + level);
        Debug.Log("setting current level : " + newL);
        PlayerPrefs.SetInt("currentLevel", level + 4);
        SceneManager.LoadScene(level + 4);
    }
}
