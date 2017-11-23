using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

	public void loadGameScene()
    {
        SceneManager.LoadScene(2);
    }

    public void loadQuestScene()
    {
        SceneManager.LoadScene(1);
    }

    public void loadTutorialScene()
    {
        SceneManager.LoadScene(3);
    }
}
