using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevelTrigger : MonoBehaviour
{
    [SerializeField] private int generateIndex;

    public static Action<int> OnGenerateLevel;

    private void OnTriggerEnter(Collider target)
    {
        if (target.tag == "Player")
        {
            OnGenerateLevel?.Invoke(generateIndex);
        }
    }
}