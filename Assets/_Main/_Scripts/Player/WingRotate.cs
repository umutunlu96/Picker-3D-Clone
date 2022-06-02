using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WingRotate : MonoBehaviour
{
    [SerializeField] bool rotateLeft;
    [SerializeField] float rotateSpeed;

    private void OnEnable()
    {
        int RotationSide = rotateLeft ? -1 : 1;
        transform.DORotate(new Vector3(0, 360 * RotationSide, 0), rotateSpeed, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
    }

    private void OnDisable()
    {
        DOTween.Kill(transform);
    }
}