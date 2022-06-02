using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static int levelIndex = 1;

    public static Action OnLevelComplete;
    public static Action OnLevelLose;


    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void LevelComplete()
    {
        levelIndex++;
        UiManager.instance.SetLevelIndexText();
        OnLevelComplete?.Invoke();
    }

    public void LoseLevel()
    {
        print("Level Lose");
        OnLevelLose?.Invoke();
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}