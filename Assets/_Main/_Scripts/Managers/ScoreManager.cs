using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public static Action OnScoreUpdate;

    public static Action OnHighScoreBeaten;

    public static Action OnHighScoreNotBeaten;

    public static int score;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        RestartScore();
    }

    public void UpdateScore()
    {
        score++;
        OnScoreUpdate?.Invoke();
    }

    private void RestartScore()
    {
        score = 0;
    }

    public void HighScoreCalculate()
    {
        if (score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
            OnHighScoreBeaten?.Invoke();
        }
        else
        {
            OnHighScoreNotBeaten?.Invoke();
        }
    }

    private void OnEnable()
    {
        GameManager.OnLevelLose += HighScoreCalculate;
    }

    private void OnDisable()
    {
        GameManager.OnLevelLose -= HighScoreCalculate;
    }
}