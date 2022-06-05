using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStateControl : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void ChangeCameraToMain()
    {
        animator.Play("MainCam");
    }

    void ChangeCameraToTunnel()
    {
        animator.Play("TunnelCam");
    }

    private void OnEnable()
    {
        Tunnel.OnTunnelEnter += ChangeCameraToTunnel;
        Tunnel.OnTunnelExit += ChangeCameraToMain;
    }

    private void OnDisable()
    {
        Tunnel.OnTunnelEnter -= ChangeCameraToTunnel;
        Tunnel.OnTunnelExit -= ChangeCameraToMain;
    }
}