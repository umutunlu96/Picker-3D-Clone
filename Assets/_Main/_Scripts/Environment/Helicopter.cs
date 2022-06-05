using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Helicopter : MonoBehaviour
{
    [Header("Propeller")]
    [SerializeField] GameObject propeller;
    [SerializeField] float rotateSpeed;
    
    [Header("Helicopter")]
    [SerializeField] float duration;
    [SerializeField] Transform[] path;

    [Header("Collectables")]
    [SerializeField] GameObject[] collectables;

    private bool canRotate;
    private Sequence sequence;

    private void Awake()
    {

    }

    private void MoveAlongPath()
    {
        sequence = DOTween.Sequence();

        foreach (var p in path)
        {
            sequence.Append(transform.DOLocalMove(p.transform.localPosition, duration));
            StartCoroutine(DropBall());
        }
    }

    private IEnumerator DropBall()
    {
        foreach (var obj in collectables)
        {
            obj.transform.SetParent(null);
            obj.SetActive(true);
            yield return new WaitForSeconds(.25f);
        }
    }

    private void Update()
    {
        if (canRotate)
            PropellerRotate();
    }

    private void PropellerRotate()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed);
    }

    private void OnEnable()
    {
        canRotate = true;
        MoveAlongPath();
    }

    private void OnDisable()
    {
        canRotate = false;
    }
}