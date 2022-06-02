using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingUpgradeTrigger : MonoBehaviour
{

    public static Action OnPlayerTakeWingUpgrade;

    private void OnTriggerEnter(Collider target)
    {
        if (target.tag == "Player")
        {
            OnPlayerTakeWingUpgrade?.Invoke();
        }
    }
}
