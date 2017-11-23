﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public void returnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void playAgain()
    {
        SceneManager.LoadScene(2);
    }
}
