using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WingUpgradeAnimation : MonoBehaviour
{
    [SerializeField] float rotateSpeed;

    private void OnEnable()
    {
        transform.DORotate(new Vector3(0, 0, 360), rotateSpeed, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
    }

    private void OnTriggerEnter(Collider target)
    {
        if (target.tag == "Player")
        {
            gameObject.SetActive(false);
        }
    }
}