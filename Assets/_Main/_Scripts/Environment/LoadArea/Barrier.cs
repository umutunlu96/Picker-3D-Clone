using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Barrier : MonoBehaviour
{
    public static Action OnBarrierrUp;

    [Header("Parameters")]
    [SerializeField] float upTime;

    [Header("Referances")]
    [SerializeField] GameObject leftBarrier;
    [SerializeField] GameObject rightBarrier;

    public void MoveBarrierUp()
    {
        leftBarrier.transform.DORotate(new Vector3(0, 0, 90), upTime);
        rightBarrier.transform.DORotate(new Vector3(0, -180, 90), upTime).OnComplete(() => OnBarrierrUp?.Invoke());
    }
}