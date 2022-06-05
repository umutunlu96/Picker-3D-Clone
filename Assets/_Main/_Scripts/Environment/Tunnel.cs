using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tunnel : MonoBehaviour
{
    public static Action OnTunnelEnter;
    public static Action OnTunnelExit;

    private void OnTriggerEnter(Collider target)
    {
        if (target.tag == "Player")
            OnTunnelEnter?.Invoke();
    }

    private void OnTriggerExit(Collider target)
    {
        if (target.tag == "Player")
            OnTunnelExit?.Invoke();
    }
}