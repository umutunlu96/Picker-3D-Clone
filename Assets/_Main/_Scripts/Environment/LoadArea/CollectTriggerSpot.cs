using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectTriggerSpot : MonoBehaviour
{
    public static Action OnPlayerEnterCollectArea;

    [SerializeField] GatherArea gatherArea; 

    private void OnTriggerEnter(Collider target)
    {
        if (target.tag == "Player")
        {
            OnPlayerEnterCollectArea?.Invoke();
            Invoke("GatherAreaTrigger", 2);
        }
    }

    private void GatherAreaTrigger()
    {
        gatherArea.checkCollectedCount = true;
    }
}