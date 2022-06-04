using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static int levelIndex = 1;

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
    }

    public void LoseLevel()
    {
        OnLevelLose?.Invoke();
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void LevelGenerator(int levelIndex)
    {
        switch (levelIndex)
        {
            case 1:
                ObjectPooler.instance.GenerateLevel1();
                break;
            case 2:
                ObjectPooler.instance.GenerateLevel2();
                break;
            case 3:
                ObjectPooler.instance.GenerateLevel3();
                LevelComplete();
                break;
        }
    }

    private void OnEnable()
    {
        GenerateLevelTrigger.OnGenerateLevel += LevelGenerator;
    }

    private void OnDisable()
    {
        GenerateLevelTrigger.OnGenerateLevel -= LevelGenerator;
    }
}