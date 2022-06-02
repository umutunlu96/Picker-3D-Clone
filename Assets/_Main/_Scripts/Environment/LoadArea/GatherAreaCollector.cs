using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatherAreaCollector : MonoBehaviour
{
    [SerializeField] GatherArea gatherArea;

    private void OnTriggerEnter(Collider target)
    {
        if (target.tag == "Collectable")
        {
            gatherArea.UpdateCollectText();
            ScoreManager.instance.UpdateScore();
        }
    }
}