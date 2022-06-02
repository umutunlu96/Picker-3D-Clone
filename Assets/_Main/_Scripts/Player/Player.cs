using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    [SerializeField] private PMovementControl pMovementControl;
    [SerializeField] private PushCollectables pushCollectables;
    [SerializeField] private GameObject leftWing;
    [SerializeField] private GameObject rightWing;


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

    public void EnableWings()
    {
        leftWing.SetActive(true);
        rightWing.SetActive(true);
    }

    public void DisableWings()
    {
        leftWing.SetActive(false);
        rightWing.SetActive(false);
    }

    private void OnEnable()
    {
        CollectTriggerSpot.OnPlayerEnterCollectArea += DisableWings;
        CollectTriggerSpot.OnPlayerEnterCollectArea += StopPlayer;
        CollectTriggerSpot.OnPlayerEnterCollectArea += Push;
        Barrier.OnBarrierrUp += MovePlayer;
        WingUpgradeTrigger.OnPlayerTakeWingUpgrade += EnableWings;
    }

    private void OnDisable()
    {
        CollectTriggerSpot.OnPlayerEnterCollectArea -= DisableWings;
        CollectTriggerSpot.OnPlayerEnterCollectArea -= StopPlayer;
        CollectTriggerSpot.OnPlayerEnterCollectArea -= Push;
        Barrier.OnBarrierrUp -= MovePlayer;
        WingUpgradeTrigger.OnPlayerTakeWingUpgrade -= EnableWings;
    }
}