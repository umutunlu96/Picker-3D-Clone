using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WingRotate : MonoBehaviour
{
    [SerializeField] bool rotateLeft;
    [SerializeField] float rotateSpeed;
    private bool canRotate = false;
    private int rotationSide = 1;

    private void Update()
    {
        if (canRotate)
            Rotate();
    }

    private void Rotate()
    {
        transform.Rotate(Vector3.up * rotationSide * Time.deltaTime * rotateSpeed);
    }

    private void OnEnable()
    {
        canRotate = true;
        rotationSide = rotateLeft ? -1 : 1;
    }

    private void OnDisable()
    {
        canRotate = false;
    }
}