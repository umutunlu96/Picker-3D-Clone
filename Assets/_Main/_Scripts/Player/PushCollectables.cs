using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PushCollectables : MonoBehaviour
{
    private float startPosZ;

    public void Push()
    {
        startPosZ = transform.localPosition.z;
        transform.DOLocalMoveZ(.35f,1,false).OnComplete(() => transform.DOLocalMoveZ(startPosZ, .5f, false));
    }
}