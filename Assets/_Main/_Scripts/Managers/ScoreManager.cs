using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public static Action OnScoreUpdate;

    public static int score;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void UpdateScore()
    {
        score++;
        OnScoreUpdate?.Invoke();
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }
}