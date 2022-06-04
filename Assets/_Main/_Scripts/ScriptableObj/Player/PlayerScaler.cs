using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScaler : MonoBehaviour
{
    [SerializeField] PlayerScalerScriptable small;
    [SerializeField] PlayerScalerScriptable medium;
    [SerializeField] PlayerScalerScriptable big;

    private void Start()
    {
        ChangeScaleSmall();
    }
    private void ChangeScaleSmall()
    {
        transform.localScale = small.scale;
    }

    private void ChangeScaleMedium()
    {
        transform.localScale = medium.scale;
    }

    private void ChangeScaleBig()
    {
        transform.localScale = big.scale;
    }

    private void ChangeScale(int index)
    {
        switch (index)
        {
            case 1:
                ChangeScaleMedium();
                break;

            case 2:
                ChangeScaleBig();
                break;

            case 3:
                ChangeScaleSmall();
                break;

            default:
                ChangeScaleSmall();
                break;
        }
    }

    private void OnEnable()
    {
        GenerateLevelTrigger.OnGenerateLevel += ChangeScale;
    }

    private void OnDisable()
    {
        GenerateLevelTrigger.OnGenerateLevel -= ChangeScale;
    }

}