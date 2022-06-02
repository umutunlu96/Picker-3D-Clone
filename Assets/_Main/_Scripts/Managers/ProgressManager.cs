using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    public static ProgressManager instance;
    public static Action<int> OnProgressIncrease;
    public static int progress;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        progress = 0;
    }

    public void IncreaseProgress()
    {
        progress++;
        OnProgressIncrease?.Invoke(progress);
    }


    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }
}