using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

	public void loadNewGameScene()
    {
        SceneManager.LoadScene(1);
    }

    public void loadPracticeScene()
    {
        SceneManager.LoadScene(8);
    }

    public void loadCreditsScene()
    {
        SceneManager.LoadScene(3);
    }

    public void loadContinueGameScene()
    {
        int currentLevel = PlayerPrefs.GetInt("currentLevel");
        if (currentLevel == 0)
            currentLevel = 1;
        SceneManager.LoadScene(currentLevel);
    }


    public void setDifficultyEasy()
    {
        PlayerPrefs.SetString("difficulty", "easy");
        PlayerPrefs.SetInt("currentLevel", 1);
        SceneManager.LoadScene(4);
    }

    public void setDifficultyMedium()
    {
        PlayerPrefs.SetString("difficulty", "medium");
        PlayerPrefs.SetInt("currentLevel", 1);
        SceneManager.LoadScene(4);

    }

    public void setDifficultyHard()
    {
        PlayerPrefs.SetString("difficulty", "hard");
        PlayerPrefs.SetInt("currentLevel", 1);
        SceneManager.LoadScene(4);
    }

    public void setDifficultyChallenger()
    {
        PlayerPrefs.SetString("difficulty", "challenger");
        PlayerPrefs.SetInt("currentLevel", 1);
        SceneManager.LoadScene(4);
    }

    public void mainMenu()
    {
        SceneManager.LoadScene(0);
    }

}
