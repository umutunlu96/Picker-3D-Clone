using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    public PMovementControl pMovementControl;
    public PushCollectables pushCollectables;


    private void Awake()
    {
        #region Sinleton
        if (instance == null)
        {
            instance = this;
        }
        #endregion
    }



    public void Push()
    {
        pushCollectables.Push();
    }

    public void StopPlayer()
    {
        pMovementControl.SetVerticalSpeed(0);
    }

    public void MovePlayer()
    {
        pMovementControl.SetVerticalSpeed(1.5f);
    }

    private void OnEnable()
    {
        CollectTriggerSpot.OnPlayerEnterCollectArea += StopPlayer;
        CollectTriggerSpot.OnPlayerEnterCollectArea += Push;
        Barrier.OnBarrierrUp += MovePlayer;
    }

    private void OnDisable()
    {
        CollectTriggerSpot.OnPlayerEnterCollectArea -= StopPlayer;
        CollectTriggerSpot.OnPlayerEnterCollectArea -= Push;
        Barrier.OnBarrierrUp -= MovePlayer;
    }
}