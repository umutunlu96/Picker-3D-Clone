using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WingUpgradeAnimation : MonoBehaviour
{
    [SerializeField] float rotateSpeed;
    private bool canRotate = true;

    private void Update()
    {
        if (canRotate)
            Rotate();
    }

    private void Rotate()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * rotateSpeed);
    }

    private void OnTriggerEnter(Collider target)
    {
        if (target.tag == "Player")
        {
            gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        canRotate = true;
    }

    private void OnDisable()
    {
        canRotate = false;
    }
}