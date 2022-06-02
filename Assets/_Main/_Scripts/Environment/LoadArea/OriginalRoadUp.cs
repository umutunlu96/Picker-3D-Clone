using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class OriginalRoadUp : MonoBehaviour
{
    [SerializeField] GameObject baseObject;

    public void MoveUpwards()
    {
        transform.DOLocalMoveY(0, 2).OnComplete(() => baseObject.GetComponent<BoxCollider>().isTrigger = false);
    }
}